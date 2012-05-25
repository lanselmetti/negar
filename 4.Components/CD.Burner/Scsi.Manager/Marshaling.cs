#if DEBUG
#define CHECK_ACCESS_VIOLATION
#endif
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading;
using TUIntPtr = System.UInt32; //Change this to UInt64 for 64-bit platform

#pragma warning disable 3021

namespace Helper
{
    /// <summary>Any marshalable object should implement this interface.</summary>
    public interface IMarshalable { void MarshalFrom(BufferWithSize buffer); void MarshalTo(BufferWithSize buffer); int MarshaledSize { get; } }

    #region Marshaler
    public static class Marshaler
    {
        private static PtrToStructureHelperDelegate __PtrToStructureHelperDelegate;
        private static SetLastWin32ErrorDelegate __SetLastWin32ErrorDelegate;

        #region Different Types of Marshalers
        private abstract class AbstractMarshaler<T>
        {
            private static AbstractMarshaler<T> __Default;
            private static int __Size = -1;
            private static int __IsBlittable = -1;

            [DebuggerHidden, DebuggerNonUserCode]
            protected AbstractMarshaler() { if (typeof(T) == typeof(object)) { throw new InvalidOperationException("Cannot marshal the Object data type. Did you mean to call the dynamic overload?"); } }

            [DebuggerHidden, DebuggerNonUserCode]
            public abstract void PtrToStructure(BufferWithSize buffer, ref T @object);
            [DebuggerHidden, DebuggerNonUserCode]
            public abstract int SizeOf(T @object);
            [DebuggerHidden, DebuggerNonUserCode]
            public abstract int StructureToPtr(T @object, BufferWithSize buffer);

            public static bool IsBlittable
            {
                [DebuggerHidden, DebuggerNonUserCode]
                get
                {
                    if (__IsBlittable == -1)
                    {
                        bool isBlittable = false;
                        var blittable = (BlittableAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(BlittableAttribute), false);
                        if (blittable != null) { isBlittable = blittable.Blittable; }
                        else if (typeof(T).IsEnum) { isBlittable = true; }
                        else
                        {
                            try
                            {
                                GCHandle.Alloc(Objects.CreateInstance<T>(), GCHandleType.Pinned).Free();
                                isBlittable = true;
                            }
                            catch { isBlittable = false; }
                        }
                        Interlocked.CompareExchange(ref __IsBlittable, isBlittable ? 1 : 0, -1);
                    }
                    return __IsBlittable != 0;
                }
            }

            public static AbstractMarshaler<T> Default
            {
                [DebuggerHidden, DebuggerNonUserCode]
                get
                {
                    if (__Default == null)
                    {
                        AbstractMarshaler<T> marshaler;
                        Type c = typeof(T);
                        if (typeof(IMarshalable).IsAssignableFrom(c))
                        { marshaler = (AbstractMarshaler<T>)Activator.CreateInstance(typeof(MarshalableMarshaler<>).MakeGenericType(new Type[] { c })); }
                        else { marshaler = new DefaultObjectMarshaler<T>(); }
                        Interlocked.CompareExchange<AbstractMarshaler<T>>(ref __Default, marshaler, null);
                    }
                    return __Default;
                }
            }

            public static int Size
            {
                [DebuggerHidden, DebuggerNonUserCode]
                get { if (__Size == -1) { Interlocked.CompareExchange(ref __Size, Marshal.SizeOf(typeof(T)), -1); } return __Size; }
            }
        }

        private sealed class DefaultObjectMarshaler<T> : AbstractMarshaler<T>
        {
            [DebuggerHidden, DebuggerNonUserCode]
            public override void PtrToStructure(BufferWithSize buffer, ref T @object) { Marshaler.DefaultPtrToStructure<T>(buffer, ref @object); }
            [DebuggerHidden, DebuggerNonUserCode]
            public override int SizeOf(T @object) { return Size; }
            [DebuggerHidden, DebuggerNonUserCode]
            public override int StructureToPtr(T @object, BufferWithSize buffer) { return Marshaler.DefaultStructureToPtr<T>(@object, buffer); }
        }

        private sealed class MarshalableMarshaler<T> : AbstractMarshaler<T> where T : IMarshalable
        {
            [DebuggerHidden, DebuggerNonUserCode]
            public override void PtrToStructure(BufferWithSize buffer, ref T @object) { @object.MarshalFrom(buffer); }
            [DebuggerHidden, DebuggerNonUserCode]
            public override int SizeOf(T @object) { return @object.MarshaledSize; }
            [DebuggerHidden, DebuggerNonUserCode]
            public override int StructureToPtr(T @object, BufferWithSize buffer) { @object.MarshalTo(buffer); return @object.MarshaledSize; }
        }
        #endregion

        [DebuggerHidden, DebuggerNonUserCode]
        public static T DefaultPtrToStructure<T>(BufferWithSize buffer) { T obj = Objects.CreateInstance<T>(); DefaultPtrToStructure<T>(buffer, ref obj); return obj; }

        [DebuggerHidden, DebuggerNonUserCode]
        public static void DefaultPtrToStructure<T>(BufferWithSize buffer, ref T @object)
        {
            buffer = buffer.ExtractSegment(0, AbstractMarshaler<T>.Size);
            if (AbstractMarshaler<T>.IsBlittable)
            {
                if (@object is ValueType) { @object = Objects.Read<T>(buffer.Address); }
                else
                {
                    GCHandle handle = GCHandle.Alloc((T)@object, GCHandleType.Pinned);
                    try { BufferWithSize.Copy(buffer, UIntPtr.Zero, new BufferWithSize(handle.AddrOfPinnedObject(), buffer.Length), UIntPtr.Zero, buffer.Length); }
                    finally { handle.Free(); }
                }
            }
            else if (@object is ValueType) { @object = (T)Marshal.PtrToStructure(buffer.Address, typeof(T)); }
            else { Marshal.PtrToStructure(buffer.Address, (T)@object); }
        }

        [DebuggerHidden, DebuggerNonUserCode]
        public static void DefaultPtrToStructure(BufferWithSize buffer, object @object)
        {
            buffer = buffer.ExtractSegment(0, Marshal.SizeOf(@object));
            Marshal.PtrToStructure(buffer.Address, @object);
        }

        [DebuggerHidden, DebuggerNonUserCode]
        public static int DefaultSizeOf<T>() { return AbstractMarshaler<T>.Size; }

        [DebuggerHidden, DebuggerNonUserCode]
        public static void DefaultStructureToPtr(object @object, BufferWithSize buffer)
        {
            buffer = buffer.ExtractSegment(0, Marshal.SizeOf(@object));
            Marshal.StructureToPtr(@object, buffer.Address, false);
        }

        [DebuggerHidden, DebuggerNonUserCode]
        public static int DefaultStructureToPtr<T>(T @object, BufferWithSize buffer)
        {
            int size = AbstractMarshaler<T>.Size;
            buffer = buffer.ExtractSegment(0, size);
            if (AbstractMarshaler<T>.IsBlittable)
            {
                if (@object is ValueType) { Objects.Write(buffer.Address, @object); }
                else
                {
                    GCHandle handle = GCHandle.Alloc(@object, GCHandleType.Pinned);
                    try { BufferWithSize.Copy(new BufferWithSize(handle.AddrOfPinnedObject(), buffer.Length), UIntPtr.Zero, buffer, UIntPtr.Zero, buffer.Length); }
                    finally { handle.Free(); }
                }
            }
            else { Marshal.StructureToPtr(@object, buffer.Address, false); }
            return size;
        }

        [SuppressUnmanagedCodeSecurity, DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int FormatMessage(int dwFlags, IntPtr lpSource, int dwMessageId, int dwLanguageId, StringBuilder lpBuffer, int nSize, IntPtr va_list_arguments);
        [SuppressUnmanagedCodeSecurity, DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr FreeLibrary(IntPtr hModule);

        [DebuggerHidden, DebuggerNonUserCode]
        public static Exception GetException(int errorCode, string message)
        {
            if (message == null) { message = GetMessage(errorCode); }
            Exception exception = null;
            switch (errorCode)
            {
                case 38:
                    exception = new EndOfStreamException(message);
                    break;
                case 50:
                    exception = new NotSupportedException(message);
                    break;
                case 120:
                    exception = new NotImplementedException(message);
                    break;
                case 2:
                    exception = new FileNotFoundException(message);
                    break;
                case 3:
                    exception = new DirectoryNotFoundException(message);
                    break;
                case 5:
                    exception = new UnauthorizedAccessException(message);
                    break;
                case 14:
                    exception = new OutOfMemoryException(message);
                    break;
                case 15:
                    exception = new DriveNotFoundException(message);
                    break;
                case 32:
                    exception = new IOException(message, errorCode | unchecked((int)0x80070000));
                    break;
                case 206:
                    exception = new PathTooLongException(message);
                    break;
                case 599:
                case 1001:
                    exception = new StackOverflowException(message);
                    break;
                case 995:
                    exception = new OperationCanceledException(message);
                    break;
                case 1450:
                    exception = new InsufficientMemoryException(message);
                    break;
                case 1460:
                    exception = new TimeoutException(message);
                    break;
                case 998:
                    exception = new AccessViolationException(message);
                    break;
            }
            if (exception == null) { exception = Marshal.GetExceptionForHR(errorCode | unchecked((int)0x8007000)); }
            return exception;
        }

        [DebuggerHidden, DebuggerNonUserCode]
        public static Exception GetExceptionForLastWin32Error() { return Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error()); }

        [DebuggerHidden, DebuggerNonUserCode]
        public static string GetMessage(int errorCode) { string msg = TryGetMessage(errorCode); if (msg == null) { Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); } return msg; }

        [SuppressUnmanagedCodeSecurity, DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DebuggerHidden, DebuggerNonUserCode]
        public static bool IsBlittable<T>() { return AbstractMarshaler<T>.IsBlittable; }

        [DebuggerHidden, DebuggerNonUserCode]
        public static bool IsBlittableSlow(Type type) { return (bool)typeof(AbstractMarshaler<>).MakeGenericType(type).GetProperty("IsBlittable").GetValue(null, null); }

        [SuppressUnmanagedCodeSecurity, DllImport("Kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr LoadLibrary(string libFilename);

        [DebuggerHidden, DebuggerNonUserCode]
        public static T PtrToStructure<T>(BufferWithSize buffer) { var obj = Objects.CreateInstance<T>(); PtrToStructure(buffer, ref obj); return obj; }

        [DebuggerHidden, DebuggerNonUserCode]
        public static void PtrToStructure<T>(BufferWithSize buffer, ref T @object)
        {
            //Trace.WriteLine(string.Format(@"Unmanaged -> Managed ({0})", typeof(T)), "Marshaler");
            AbstractMarshaler<T>.Default.PtrToStructure(buffer, ref @object);
        }

        [DebuggerHidden, DebuggerNonUserCode]
        public static unsafe T PtrToStructure<T>(byte[] buffer, int bufferOffset) { fixed (byte* pBuffer = &buffer[bufferOffset]) { return PtrToStructure<T>(new BufferWithSize((IntPtr)pBuffer, buffer.Length - bufferOffset)); } }

        [DebuggerHidden, DebuggerNonUserCode]
        public static unsafe void PtrToStructure<T>(byte[] buffer, int bufferOffset, ref T @object) { fixed (byte* pBuffer = &buffer[bufferOffset]) { PtrToStructure<T>(new BufferWithSize((IntPtr)pBuffer, buffer.Length - bufferOffset), ref @object); return; } }

        [DebuggerHidden, DebuggerNonUserCode]
        public static void PtrToStructureHelper(IntPtr ptr, object structure, bool allowValueClasses)
        {
            if (__PtrToStructureHelperDelegate == null)
            {
                PtrToStructureHelperDelegate @delegate = (PtrToStructureHelperDelegate)Delegate.CreateDelegate(typeof(PtrToStructureHelperDelegate), typeof(Marshal).GetMethod("PtrToStructureHelper", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static), true);
                Interlocked.CompareExchange<PtrToStructureHelperDelegate>(ref __PtrToStructureHelperDelegate, @delegate, null);
            }
            __PtrToStructureHelperDelegate(ptr, structure, allowValueClasses);
        }

        [DebuggerHidden, DebuggerNonUserCode]
        public static void SetLastWin32Error(int error)
        {
            if (__SetLastWin32ErrorDelegate == null)
            {
                SetLastWin32ErrorDelegate @delegate = (SetLastWin32ErrorDelegate)Delegate.CreateDelegate(typeof(SetLastWin32ErrorDelegate), typeof(Marshal).GetMethod("SetLastWin32Error", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static), true);
                Interlocked.CompareExchange<SetLastWin32ErrorDelegate>(ref __SetLastWin32ErrorDelegate, @delegate, null);
            }
            __SetLastWin32ErrorDelegate(error);
        }

        [DebuggerHidden, DebuggerNonUserCode]
        public static bool ShouldStackAlloc(int size) { return (size < 0x800); }

        [DebuggerHidden, DebuggerNonUserCode]
        public static bool ShouldStackAlloc(IntPtr size) { return ((int)size < 0x800); }

        [DebuggerHidden, DebuggerNonUserCode]
        [CLSCompliant(false)]
        public static bool ShouldStackAlloc(uint size) { return (size < 0x800); }

        [DebuggerHidden, DebuggerNonUserCode]
        public static int SizeOf<T>(T @object) { return AbstractMarshaler<T>.Default.SizeOf(@object); }

        //Note: we must support UNALIGNED data here (some of my projects need this)
        [DebuggerHidden, DebuggerNonUserCode]
        [CLSCompliant(false)]
        public static unsafe void StringToPtrUni(string @string, char* ptr) { fixed (char* pString = @string) { for (int i = 0; i < @string.Length; i++) { ptr[i] = pString[i]; } } }

        //Note: we must support UNALIGNED data here (some of my projects need this)
        [DebuggerHidden, DebuggerNonUserCode]
        public static unsafe void StringToPtrUni(string @string, IntPtr ptr) { StringToPtrUni(@string, (char*)ptr); }

        [DebuggerHidden, DebuggerNonUserCode]
        public static int StructureToPtr<T>(T @object, BufferWithSize buffer)
        {
            //Trace.WriteLine(string.Format(@"Managed -> Unmanaged ({0})", @object), "Marshaler");
            return AbstractMarshaler<T>.Default.StructureToPtr(@object, buffer);
        }

        [DebuggerHidden, DebuggerNonUserCode]
        public static int StructureToPtr<T>(T @object, byte[] buffer, int bufferOffset) { unsafe { fixed (byte* pBuffer = &buffer[bufferOffset]) { return StructureToPtr<T>(@object, new BufferWithSize((IntPtr)pBuffer, buffer.Length - bufferOffset)); } } }

        [DebuggerHidden, DebuggerNonUserCode]
        public static byte[] StructureToPtr<T>(T @object) { var bytes = new byte[SizeOf(@object)]; StructureToPtr(@object, bytes, 0); return bytes; }

        [DebuggerHidden, DebuggerNonUserCode, DebuggerStepThrough]
        public static void ThrowException(int errorCode) { ThrowException(errorCode, null); }

        [DebuggerHidden, DebuggerNonUserCode, DebuggerStepThrough]
        public static void ThrowException(int errorCode, string message) { throw GetException(errorCode, message); }

        [DebuggerHidden, DebuggerNonUserCode, DebuggerStepThrough]
        public static void ThrowLastWin32Error() { Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error()); }

        [DebuggerHidden, DebuggerNonUserCode]
        public static string TryGetMessage(int errorCode) { StringBuilder lpBuffer = new StringBuilder(0x200); if (FormatMessage(0x1200, IntPtr.Zero, errorCode, 0, lpBuffer, lpBuffer.Capacity, IntPtr.Zero) != 0) { return lpBuffer.ToString(); } return null; }

        [DebuggerHidden, DebuggerNonUserCode]
        public static string TryGetMessage(int errorCode, IntPtr hModule)
        {
            StringBuilder lpBuffer = new StringBuilder(0x200);
            if (FormatMessage(((hModule != IntPtr.Zero) ? 0x800 : 0x1000) | 0x200, hModule, errorCode, 0, lpBuffer, lpBuffer.Capacity, IntPtr.Zero) != 0)
            { return lpBuffer.ToString(); }
            return null;
        }

        [DebuggerHidden, DebuggerNonUserCode]
        public static string TryGetMessage(int errorCode, string moduleName, bool assumeModuleLoaded)
        {
            var lpBuffer = new StringBuilder(0x200);
            IntPtr hModule = assumeModuleLoaded ? GetModuleHandle(moduleName) : LoadLibrary(moduleName);
            try { if (FormatMessage(0xa00, hModule, errorCode, 0, lpBuffer, lpBuffer.Capacity, IntPtr.Zero) != 0) { return lpBuffer.ToString(); } }
            finally { if (!assumeModuleLoaded) { FreeLibrary(hModule); } }
            return null;
        }

        private delegate void PtrToStructureHelperDelegate(IntPtr ptr, object structure, bool allowValueClasses);

        private delegate void SetLastWin32ErrorDelegate(int error);

#if false
		public delegate void MarshalDelegate<T>(BufferWithSize buffer, ref T @object);

		/// <param name="includeGiven">Whether to include or exclude the fields given.</param>
		public static MarshalDelegate<T> CreateDefaultMarshaler<T>(bool includeGiven, params string[] fieldNames)
		{ return (MarshalDelegate<T>)CreateDefaultMarshaler(typeof(T), includeGiven, fieldNames); }

		/// <param name="includeGiven">Whether to include or exclude the fields given.</param>
		private static Delegate CreateDefaultMarshaler(Type type, bool includeGiven, params string[] fieldNames)
		{
			if (fieldNames == null) { throw new ArgumentNullException("fieldNames"); }
			Array.Sort(fieldNames);
			var method = new DynamicMethod(type.Name + "__Marshaler", null, new Type[] { typeof(BufferWithSize), type.MakeByRefType() }, type, true);
			var gen = method.GetILGenerator();
			foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				if (includeGiven == (Array.BinarySearch(fieldNames, field.Name) >= 0))
				{
					//Pushes address of field onto stack
					gen.Emit(OpCodes.Ldarg_1);
					if (!type.IsValueType)
					{ gen.Emit(OpCodes.Ldind_Ref); }
					else { }
					gen.Emit(OpCodes.Ldflda, field);

					//Pushes address of buffer onto stack
					gen.Emit(OpCodes.Ldarga_S, 0);
					gen.Emit(OpCodes.Call, typeof(BufferWithSize).GetProperty("Address").GetGetMethod());

					//*
					//Pushes field offset onto stack
					gen.Emit(OpCodes.Ldc_I4, (int)Marshaler.OffsetOf(field.FieldHandle));
					gen.Emit(OpCodes.Conv_Ovf_U);

					//Gets the pointer to the field
					gen.Emit(OpCodes.Add_Ovf_Un);

					gen.Emit(OpCodes.Cpobj, field.FieldType);
					//*/
				}
			}
			gen.Emit(OpCodes.Ret);
			var del = method.CreateDelegate(typeof(MarshalDelegate<>).MakeGenericType(type));
			return del;
		}
#endif

    }
    #endregion

    #region BufferWithSize
    /// <summary>Represents a buffer in memory that can be accessed safely. If you receive any <see cref="OverflowException"/> while using this class, it signals an access violation.</summary>
    [DebuggerStepThrough]
    [DebuggerDisplay("{Address} - {(global::System.IntPtr)((byte*)Address + unchecked((ulong)Length))} (Length = {Length})"), DebuggerTypeProxy(typeof(BufferWithSizeDebugView))]
    public struct BufferWithSize
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public static BufferWithSize Zero;
        public readonly IntPtr Address;
        [CLSCompliant(false)]
        public readonly UIntPtr Length;

        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public unsafe BufferWithSize(byte* address, int count) { this.Address = (IntPtr)address; this.Length = (UIntPtr)count; }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public unsafe BufferWithSize(byte* address, long count) { this.Address = (IntPtr)address; this.Length = (UIntPtr)count; }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public unsafe BufferWithSize(byte* address, IntPtr count) { this.Address = (IntPtr)address; unsafe { this.Length = ToUIntPtr(count); } }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public unsafe BufferWithSize(byte* address, uint count) { this.Address = (IntPtr)address; this.Length = (UIntPtr)count; }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public unsafe BufferWithSize(byte* address, ulong count) { this.Address = (IntPtr)address; this.Length = (UIntPtr)count; }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public unsafe BufferWithSize(byte* address, UIntPtr count) { this.Address = (IntPtr)address; this.Length = count; }
        [DebuggerHidden, DebuggerNonUserCode]
        public BufferWithSize(IntPtr address, int count) { this.Address = address; this.Length = (UIntPtr)count; }
        [DebuggerHidden, DebuggerNonUserCode]
        public BufferWithSize(IntPtr address, long count) { this.Address = address; this.Length = (UIntPtr)count; }
        [DebuggerHidden, DebuggerNonUserCode]
        public BufferWithSize(IntPtr address, IntPtr count) { this.Address = address; unsafe { this.Length = ToUIntPtr(count); } }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public BufferWithSize(IntPtr address, uint count) { this.Address = address; this.Length = (UIntPtr)count; }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public BufferWithSize(IntPtr address, ulong count) { this.Address = address; this.Length = (UIntPtr)count; }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public BufferWithSize(IntPtr address, UIntPtr count) { this.Address = address; this.Length = count; }


        [DebuggerHidden, DebuggerNonUserCode]
        public static BufferWithSize AllocHGlobal(int length) { return new BufferWithSize(Marshal.AllocHGlobal((IntPtr)length), (UIntPtr)length); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public static BufferWithSize AllocHGlobal(uint length) { return new BufferWithSize(Marshal.AllocHGlobal((IntPtr)length), (UIntPtr)length); }
        [DebuggerHidden, DebuggerNonUserCode]
        public static BufferWithSize AllocHGlobal(long length) { return new BufferWithSize(Marshal.AllocHGlobal((IntPtr)length), (UIntPtr)length); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public static BufferWithSize AllocHGlobal(ulong length) { return new BufferWithSize(Marshal.AllocHGlobal((IntPtr)length), (UIntPtr)length); }
        [DebuggerHidden, DebuggerNonUserCode]
        public static BufferWithSize AllocHGlobal(IntPtr length) { unsafe { return new BufferWithSize(Marshal.AllocHGlobal(length), ToUIntPtr(length)); } }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public static BufferWithSize AllocHGlobal(UIntPtr length) { unsafe { return new BufferWithSize(Marshal.AllocHGlobal((IntPtr)(void*)length), length); } }

        [DebuggerHidden, DebuggerNonUserCode]
        public static BufferWithSize ReAllocHGlobal(BufferWithSize buffer, int newSize) { return ReAllocHGlobal(buffer, (IntPtr)newSize); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public static BufferWithSize ReAllocHGlobal(BufferWithSize buffer, uint newSize) { return ReAllocHGlobal(buffer, (IntPtr)newSize); }
        [DebuggerHidden, DebuggerNonUserCode]
        public static BufferWithSize ReAllocHGlobal(BufferWithSize buffer, long newSize) { return ReAllocHGlobal(buffer, (IntPtr)newSize); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public static BufferWithSize ReAllocHGlobal(BufferWithSize buffer, ulong newSize) { return ReAllocHGlobal(buffer, (IntPtr)newSize); }
        [DebuggerHidden, DebuggerNonUserCode]
        public static BufferWithSize ReAllocHGlobal(BufferWithSize buffer, IntPtr newSize) { return new BufferWithSize(Marshal.ReAllocHGlobal(buffer.Address, newSize), ToUIntPtr(newSize)); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public static BufferWithSize ReAllocHGlobal(BufferWithSize buffer, UIntPtr newSize) { unsafe { return ReAllocHGlobal(buffer, (IntPtr)(void*)newSize); } }

        [DebuggerHidden, DebuggerNonUserCode]
        public static void FreeHGlobal(BufferWithSize buffer) { Marshal.FreeHGlobal(buffer.Address); }

        [DebuggerHidden, DebuggerNonUserCode]
        public static void Copy(BufferWithSize source, int sourceIndex, BufferWithSize destination, int destinationIndex, int count) { Copy(source, (UIntPtr)sourceIndex, destination, (UIntPtr)destinationIndex, (UIntPtr)count); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public static void Copy(BufferWithSize source, uint sourceIndex, BufferWithSize destination, uint destinationIndex, uint count) { Copy(source, (UIntPtr)sourceIndex, destination, (UIntPtr)destinationIndex, (UIntPtr)count); }
        [DebuggerHidden, DebuggerNonUserCode]
        public static void Copy(BufferWithSize source, long sourceIndex, BufferWithSize destination, long destinationIndex, long count) { Copy(source, (UIntPtr)sourceIndex, destination, (UIntPtr)destinationIndex, (UIntPtr)count); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public static void Copy(BufferWithSize source, ulong sourceIndex, BufferWithSize destination, ulong destinationIndex, ulong count) { Copy(source, (UIntPtr)sourceIndex, destination, (UIntPtr)destinationIndex, (UIntPtr)count); }

        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public static void Copy(BufferWithSize source, UIntPtr sourceIndex, BufferWithSize destination, UIntPtr destinationIndex, UIntPtr count)
        {
#if CHECK_ACCESS_VIOLATION
            if ((TUIntPtr)sourceIndex + (TUIntPtr)count > (TUIntPtr)source.Length) { ThrowAccessViolation(); }
            if ((TUIntPtr)destinationIndex + (TUIntPtr)count > (TUIntPtr)destination.Length) { ThrowAccessViolation(); }
#endif
            unsafe { Native.memcpyimpl((byte*)source.Address + (TUIntPtr)sourceIndex, (byte*)destination.Address + (TUIntPtr)destinationIndex, (int)count); }
        }

        [DebuggerHidden, DebuggerNonUserCode]
        public void CopyFrom(int destinationIndex, byte[] source, int sourceIndex, int count) { this.CopyFrom((UIntPtr)destinationIndex, source, (UIntPtr)sourceIndex, (UIntPtr)count); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public void CopyFrom(uint destinationIndex, byte[] source, uint sourceIndex, uint count) { this.CopyFrom((UIntPtr)destinationIndex, source, (UIntPtr)sourceIndex, (UIntPtr)count); }
        [DebuggerHidden, DebuggerNonUserCode]
        public void CopyFrom(long destinationIndex, byte[] source, long sourceIndex, long count) { this.CopyFrom((UIntPtr)destinationIndex, source, (UIntPtr)sourceIndex, (UIntPtr)count); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public void CopyFrom(ulong destinationIndex, byte[] source, ulong sourceIndex, ulong count) { this.CopyFrom((UIntPtr)destinationIndex, source, (UIntPtr)sourceIndex, (UIntPtr)count); }
        [DebuggerHidden, DebuggerNonUserCode]
        public void CopyFrom(IntPtr destinationIndex, byte[] source, IntPtr sourceIndex, IntPtr count) { unsafe { this.CopyFrom(ToUIntPtr(destinationIndex), source, ToUIntPtr(sourceIndex), ToUIntPtr(count)); } }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public void CopyFrom(UIntPtr destinationIndex, byte[] source, UIntPtr sourceIndex, UIntPtr count) { unsafe { fixed (byte* pFrom = source) { Copy(new BufferWithSize(pFrom, source.Length), sourceIndex, this, destinationIndex, count); } } }

        [DebuggerHidden, DebuggerNonUserCode]
        public void CopyTo(int sourceIndex, byte[] destination, int destinationIndex, int count) { this.CopyTo((UIntPtr)sourceIndex, destination, (UIntPtr)destinationIndex, (UIntPtr)count); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public void CopyTo(uint sourceIndex, byte[] destination, uint destinationIndex, uint count) { this.CopyTo((UIntPtr)sourceIndex, destination, (UIntPtr)destinationIndex, (UIntPtr)count); }
        [DebuggerHidden, DebuggerNonUserCode]
        public void CopyTo(long sourceIndex, byte[] destination, long destinationIndex, long count) { this.CopyTo((UIntPtr)sourceIndex, destination, (UIntPtr)destinationIndex, (UIntPtr)count); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public void CopyTo(ulong sourceIndex, byte[] destination, ulong destinationIndex, ulong count) { this.CopyTo((UIntPtr)sourceIndex, destination, (UIntPtr)destinationIndex, (UIntPtr)count); }
        [DebuggerHidden, DebuggerNonUserCode]
        public void CopyTo(IntPtr sourceIndex, byte[] destination, IntPtr destinationIndex, IntPtr count) { this.CopyTo(ToUIntPtr(sourceIndex), destination, ToUIntPtr(destinationIndex), ToUIntPtr(count)); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public void CopyTo(UIntPtr sourceIndex, byte[] destination, UIntPtr destinationIndex, UIntPtr count) { unsafe { fixed (byte* pTo = destination) { Copy(this, sourceIndex, new BufferWithSize(pTo, destination.Length), destinationIndex, count); } } }

        [DebuggerHidden, DebuggerNonUserCode]
        public bool Equals(BufferWithSize other) { return ((this.Address == other.Address) & (this.Length == other.Length)); }
        [DebuggerHidden, DebuggerNonUserCode]
        public override bool Equals(object obj) { return ((obj is BufferWithSize) && this.Equals((BufferWithSize)obj)); }

        [DebuggerHidden, DebuggerNonUserCode]
        public BufferWithSize ExtractSegment(int startIndex) { return this.ExtractSegment((UIntPtr)startIndex); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public BufferWithSize ExtractSegment(uint startIndex) { return this.ExtractSegment((UIntPtr)startIndex); }
        [DebuggerHidden, DebuggerNonUserCode]
        public BufferWithSize ExtractSegment(long startIndex) { return this.ExtractSegment((UIntPtr)startIndex); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public BufferWithSize ExtractSegment(ulong startIndex) { return this.ExtractSegment((UIntPtr)startIndex); }
        [DebuggerHidden, DebuggerNonUserCode]
        public BufferWithSize ExtractSegment(IntPtr startIndex) { unsafe { return this.ExtractSegment(ToUIntPtr(startIndex)); } }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public BufferWithSize ExtractSegment(UIntPtr startIndex) { return this.ExtractSegment(startIndex, (UIntPtr)((TUIntPtr)this.Length - (TUIntPtr)startIndex)); }
        [DebuggerHidden, DebuggerNonUserCode]
        public BufferWithSize ExtractSegment(int startIndex, int count) { return this.ExtractSegment((UIntPtr)startIndex, (UIntPtr)count); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public BufferWithSize ExtractSegment(uint startIndex, uint count) { return this.ExtractSegment((UIntPtr)startIndex, (UIntPtr)count); }
        [DebuggerHidden, DebuggerNonUserCode]
        public BufferWithSize ExtractSegment(long startIndex, long count) { return this.ExtractSegment((UIntPtr)startIndex, (UIntPtr)count); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public BufferWithSize ExtractSegment(ulong startIndex, ulong count) { return this.ExtractSegment((UIntPtr)startIndex, (UIntPtr)count); }
        [DebuggerHidden, DebuggerNonUserCode]
        public BufferWithSize ExtractSegment(IntPtr startIndex, IntPtr count) { unsafe { return this.ExtractSegment(ToUIntPtr(startIndex), ToUIntPtr(count)); } }

        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public BufferWithSize ExtractSegment(UIntPtr startIndex, UIntPtr count)
        {
#if CHECK_ACCESS_VIOLATION
            if ((TUIntPtr)startIndex + (TUIntPtr)count > (TUIntPtr)this.Length)
            { ThrowAccessViolation(); }
#endif
            unsafe { return new BufferWithSize((byte*)this.Address + (TUIntPtr)startIndex, count); }
        }

        [DebuggerHidden, DebuggerNonUserCode]
        public override int GetHashCode() { return this.Address.GetHashCode() ^ this.Length.GetHashCode(); }

        [DebuggerHidden, DebuggerNonUserCode]
        public void Initialize() { unsafe { Native.ZeroMemory((byte*)this.Address, this.Length64); } }
        [DebuggerHidden, DebuggerNonUserCode]
        public void Initialize(int startIndex) { this.Initialize((UIntPtr)startIndex); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public void Initialize(uint startIndex) { this.Initialize((UIntPtr)startIndex); }
        [DebuggerHidden, DebuggerNonUserCode]
        public void Initialize(long startIndex) { this.Initialize((UIntPtr)startIndex); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public void Initialize(ulong startIndex) { this.Initialize((UIntPtr)startIndex); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public void Initialize(UIntPtr startIndex) { this.ExtractSegment(startIndex).Initialize(); }
        [DebuggerHidden, DebuggerNonUserCode]
        public void Initialize(int startIndex, int length) { this.Initialize((UIntPtr)startIndex, length); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public void Initialize(uint startIndex, uint length) { this.Initialize((UIntPtr)startIndex, length); }
        [DebuggerHidden, DebuggerNonUserCode]
        public void Initialize(long startIndex, int length) { this.Initialize((UIntPtr)startIndex, length); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public void Initialize(ulong startIndex, uint length) { this.Initialize((UIntPtr)startIndex, length); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public void Initialize(UIntPtr startIndex, int length) { this.Initialize(startIndex, (uint)length); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public void Initialize(UIntPtr startIndex, uint length) { this.ExtractSegment(startIndex, (UIntPtr)length).Initialize(); }

        [DebuggerHidden, DebuggerNonUserCode]
        public static bool operator ==(BufferWithSize left, BufferWithSize right) { return left.Equals(right); }
        [DebuggerHidden, DebuggerNonUserCode]
        public static bool operator !=(BufferWithSize left, BufferWithSize right) { return !left.Equals(right); }

        [DebuggerHidden, DebuggerNonUserCode]
        public byte[] ToArray() { return this.ToArray(UIntPtr.Zero); }
        [DebuggerHidden, DebuggerNonUserCode]
        public byte[] ToArray(int index) { return this.ToArray((UIntPtr)index); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public byte[] ToArray(uint index) { return this.ToArray((UIntPtr)index); }
        [DebuggerHidden, DebuggerNonUserCode]
        public byte[] ToArray(long index) { return this.ToArray((UIntPtr)index); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public byte[] ToArray(ulong index) { return this.ToArray((UIntPtr)index); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public byte[] ToArray(UIntPtr index) { return this.ToArray(index, (UIntPtr)((TUIntPtr)this.Length - (TUIntPtr)index)); }
        [DebuggerHidden, DebuggerNonUserCode]
        public byte[] ToArray(int index, int count) { return this.ToArray((UIntPtr)index, (UIntPtr)count); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public byte[] ToArray(uint index, uint count) { return this.ToArray((UIntPtr)index, (UIntPtr)count); }
        [DebuggerHidden, DebuggerNonUserCode]
        public byte[] ToArray(long index, long count) { return this.ToArray((UIntPtr)index, (UIntPtr)count); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public byte[] ToArray(ulong index, ulong count) { return this.ToArray((UIntPtr)index, (UIntPtr)count); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public byte[] ToArray(UIntPtr index, UIntPtr count) { var arr = new byte[(TUIntPtr)count]; this.CopyTo(index, arr, UIntPtr.Zero, count); return arr; }

        [DebuggerHidden, DebuggerNonUserCode]
        public override string ToString() { return string.Format("Address = 0x{0:X}, Length = 0x{1:X})", (TUIntPtr)this.Address, (TUIntPtr)this.Length); }

        [DebuggerHidden, DebuggerNonUserCode]
        public string ToStringAnsi(int offset, int byteLength) { return this.ToStringAnsi((UIntPtr)offset, (UIntPtr)byteLength); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public string ToStringAnsi(uint offset, uint byteLength) { return this.ToStringAnsi((UIntPtr)offset, (UIntPtr)byteLength); }
        [DebuggerHidden, DebuggerNonUserCode]
        public string ToStringAnsi(long offset, long byteLength) { return this.ToStringAnsi((UIntPtr)offset, (UIntPtr)byteLength); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public string ToStringAnsi(ulong offset, ulong byteLength) { return this.ToStringAnsi((UIntPtr)offset, (UIntPtr)byteLength); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public string ToStringAnsi(UIntPtr offset, UIntPtr byteLength) { return this.ExtractSegment(offset, byteLength).ToStringAnsi(); }
        [DebuggerHidden, DebuggerNonUserCode]
        public string ToStringAnsi() { return Marshal.PtrToStringAnsi(this.Address, this.Length32); }

        [DebuggerHidden, DebuggerNonUserCode]
        public string ToStringUni(int offset, int byteLength) { return this.ToStringUni((UIntPtr)offset, (UIntPtr)byteLength); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public string ToStringUni(uint offset, uint byteLength) { return this.ToStringUni((UIntPtr)offset, (UIntPtr)byteLength); }
        [DebuggerHidden, DebuggerNonUserCode]
        public string ToStringUni(long offset, long byteLength) { return this.ToStringUni((UIntPtr)offset, (UIntPtr)byteLength); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public string ToStringUni(ulong offset, ulong byteLength) { return this.ToStringUni((UIntPtr)offset, (UIntPtr)byteLength); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public string ToStringUni(UIntPtr offset, UIntPtr byteLength) { return this.ExtractSegment(offset, byteLength).ToStringUni(); }
        [DebuggerHidden, DebuggerNonUserCode]
        public string ToStringUni() { return Marshal.PtrToStringUni(this.Address, this.Length32 >> 1); }

        public byte this[int index] { [DebuggerHidden, DebuggerNonUserCode] get { return this[(UIntPtr)index]; } [DebuggerHidden, DebuggerNonUserCode] set { this[(UIntPtr)index] = value; } }
        [CLSCompliant(false)]
        public byte this[uint index] { [DebuggerHidden, DebuggerNonUserCode] get { return this[(UIntPtr)index]; } [DebuggerHidden, DebuggerNonUserCode] set { this[(UIntPtr)index] = value; } }
        public byte this[long index] { [DebuggerHidden, DebuggerNonUserCode] get { return this[(UIntPtr)index]; } [DebuggerHidden, DebuggerNonUserCode] set { this[(UIntPtr)index] = value; } }
        [CLSCompliant(false)]
        public byte this[ulong index] { [DebuggerHidden, DebuggerNonUserCode] get { return this[(UIntPtr)index]; } [DebuggerHidden, DebuggerNonUserCode] set { this[(UIntPtr)index] = value; } }

        [CLSCompliant(false)]
        public byte this[UIntPtr index]
        {
            [DebuggerHidden, DebuggerNonUserCode]
            get
            {
#if CHECK_ACCESS_VIOLATION
                if ((TUIntPtr)index >= (TUIntPtr)this.Length) { ThrowAccessViolation(); }
#endif
                unsafe { return ((byte*)this.Address)[(TUIntPtr)index]; }
            }
            [DebuggerHidden, DebuggerNonUserCode]
            set
            {
#if CHECK_ACCESS_VIOLATION
                if ((TUIntPtr)index >= (TUIntPtr)this.Length) { ThrowAccessViolation(); }
#endif
                unsafe { ((byte*)this.Address)[(TUIntPtr)index] = value; }
            }
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public int Length32 { [DebuggerHidden, DebuggerNonUserCode] get { return (int)this.Length; } }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        public long Length64 { [DebuggerHidden, DebuggerNonUserCode] get { return (long)this.Length; } }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [CLSCompliant(false)]
        public uint LengthU32 { [DebuggerHidden, DebuggerNonUserCode] get { return (uint)this.Length; } }
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        [CLSCompliant(false)]
        public ulong LengthU64 { [DebuggerHidden, DebuggerNonUserCode] get { return (TUIntPtr)this.Length; } }

        [DebuggerHidden, DebuggerNonUserCode]
        public T Read<T>() where T : struct { return this.Read<T>(UIntPtr.Zero); }
        [DebuggerHidden, DebuggerNonUserCode]
        public T Read<T>(int byteOffset) where T : struct { return this.Read<T>((UIntPtr)byteOffset); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public T Read<T>(uint byteOffset) where T : struct { return this.Read<T>((UIntPtr)byteOffset); }
        [DebuggerHidden, DebuggerNonUserCode]
        public T Read<T>(long byteOffset) where T : struct { return this.Read<T>((UIntPtr)byteOffset); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public T Read<T>(ulong byteOffset) where T : struct { return this.Read<T>((UIntPtr)byteOffset); }
        [DebuggerHidden, DebuggerNonUserCode]
        public T Read<T>(IntPtr byteOffset) where T : struct { unsafe { return this.Read<T>(ToUIntPtr(byteOffset)); } }

        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public unsafe T Read<T>(UIntPtr byteOffset) where T : struct
        {
#if CHECK_ACCESS_VIOLATION
            var size = (UIntPtr)Objects.SizeOf<T>();
            checked
            {
                if ((TUIntPtr)this.Length - (TUIntPtr)byteOffset < (TUIntPtr)size)
                { ThrowAccessViolation(); }
            }
#endif
            return Objects.Read<T>((IntPtr)((byte*)this.Address + (TUIntPtr)byteOffset));
        }

        [DebuggerHidden, DebuggerNonUserCode]
        public void Write<T>(T value) where T : struct { this.Write<T>(value, UIntPtr.Zero); }
        [DebuggerHidden, DebuggerNonUserCode]
        public void Write<T>(T value, int byteOffset) where T : struct { this.Write<T>(value, (UIntPtr)byteOffset); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public void Write<T>(T value, uint byteOffset) where T : struct { this.Write<T>(value, (UIntPtr)byteOffset); }
        [DebuggerHidden, DebuggerNonUserCode]
        public void Write<T>(T value, long byteOffset) where T : struct { this.Write<T>(value, (UIntPtr)byteOffset); }
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public void Write<T>(T value, ulong byteOffset) where T : struct { this.Write<T>(value, (UIntPtr)byteOffset); }
        [DebuggerHidden, DebuggerNonUserCode]
        public void Write<T>(T value, IntPtr byteOffset) where T : struct { unsafe { this.Write<T>(value, ToUIntPtr(byteOffset)); } }

        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public unsafe void Write<T>(T value, UIntPtr byteOffset) where T : struct
        {
#if CHECK_ACCESS_VIOLATION
            var size = (UIntPtr)Objects.SizeOf<T>();
            checked
            {
                if ((TUIntPtr)this.Length - (TUIntPtr)byteOffset < (TUIntPtr)size)
                { ThrowAccessViolation(); }
            }
#endif
            Objects.Write((IntPtr)((byte*)this.Address + (TUIntPtr)byteOffset), value);
        }

        [DebuggerHidden, DebuggerNonUserCode]
        private static UIntPtr ToUIntPtr(IntPtr value)
        {
#if DEBUG
            if ((long)value < 0) { throw new OverflowException(); }
#endif
            unsafe { return *(UIntPtr*)(&value); }
        }

#if CHECK_ACCESS_VIOLATION
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes"), DebuggerStepThrough, DebuggerHidden]
        private static void ThrowAccessViolation(Exception inner) { throw new AccessViolationException(Marshaler.GetMessage(998), inner); }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2201:DoNotRaiseReservedExceptionTypes"), DebuggerStepThrough, DebuggerHidden]
        private static void ThrowAccessViolation() { throw new AccessViolationException(Marshaler.GetMessage(998)); }
#endif

        private sealed class BufferWithSizeDebugView { private BufferWithSize buffer; [DebuggerHidden, DebuggerNonUserCode] public BufferWithSizeDebugView(BufferWithSize buffer) { this.buffer = buffer; } [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)] public byte[] Data { [DebuggerHidden, DebuggerNonUserCode] get { return this.buffer.ToArray(); } } }
    }
    #endregion

    #region Objects
    public static class Objects //Important: DO NOT RENAME THIS CLASS OR ITS METHOD OR THE NAMESPACE; optimizations are hardcoded in my merger library and won't work otherwise
    {
        [DebuggerHidden, DebuggerNonUserCode]
        public static T CreateInstance<T>() { return Object<T>.Construct(); }

        private static class Array<T> { public static readonly T[] ArrayOfTwoElements = new T[2];}

        //These are all hacks but they work!! :D
        [CLSCompliant(false)]
        [DebuggerHidden, DebuggerNonUserCode]
        public static uint SizeOf<T>()
        {
#if !METHOD_1
            TypedReference elem1 = __makeref(Array<T>.ArrayOfTwoElements[0] ), elem2 = __makeref(Array<T>.ArrayOfTwoElements[1] ); unsafe { return (uint)((byte*)*(IntPtr*)(&elem2) - (byte*)*(IntPtr*)(&elem1)); }
#else
			var o = default(ComboObject<T>); unsafe { return (uint)(&o.NextByte - &o.Byte0) - sizeof(byte); }
#endif
        }

        [DebuggerHidden, DebuggerNonUserCode]
        public static T Read<T>(IntPtr address)
        {
            var obj = default(T);
            var tr = __makeref(obj );
            unsafe { *(IntPtr*)(&tr) = address; }
            return __refvalue( tr,T );
        }

        [DebuggerHidden, DebuggerNonUserCode]
        public static void Write<T>(IntPtr address, T value)
        {
            var obj = default(T);
            var tr = __makeref(obj );
            unsafe { *(IntPtr*)(&tr) = address; }
            __refvalue( tr, T ) = value;
        }

        [DebuggerHidden, DebuggerNonUserCode]
        public static RuntimeTypeHandle TypeOf<T>() { var obj = default(T); var r = __makeref(obj );unsafe { return *(RuntimeTypeHandle*)&((IntPtr*)(&r))[1]; } }
        [DebuggerHidden, DebuggerNonUserCode]
        public static TTo ConvertNoCast<TFrom, TTo>(TFrom value) { var r = __makeref(value ); unsafe { *(RuntimeTypeHandle*)&((IntPtr*)(&r))[1] = TypeOf<TTo>(); } return __refvalue( r,TTo ); }

        [DebuggerHidden, DebuggerNonUserCode]
        public static T ShiftLeft<T>(T value, IntPtr shift) { return Object<T>.ShiftLeft(value, shift); }
        [DebuggerHidden, DebuggerNonUserCode]
        public static T ShiftRightUnsigned<T>(T value, IntPtr shift) { return Object<T>.ShiftRightUnsigned(value, shift); }

        //private static class Array<T> { public static readonly T[] ArrayOfTwoElements = new T[2]; }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct ComboObject<T> { public byte Byte0; public T Value; public byte NextByte; }

        private static class Object<T>
        {
            private static readonly bool IsValueType = typeof(T).IsValueType;
            private static ConstructorDelegate __Constructor;
            private static ShiftDelegate __ShiftLeft;
            private static ShiftDelegate __ShiftRightUnsigned;

            [DebuggerHidden, DebuggerNonUserCode]
            public static T ShiftLeft(T value, IntPtr shift)
            {
                if (__ShiftLeft == null)
                {
                    var dyn = new DynamicMethod(@"ShiftLeft", typeof(T), new Type[] { typeof(T), typeof(IntPtr) }, typeof(T));
                    var gen = dyn.GetILGenerator();
                    gen.Emit(OpCodes.Ldarg_0);
                    gen.Emit(OpCodes.Ldarg_1);
                    gen.Emit(OpCodes.Shl);
                    gen.Emit(OpCodes.Ret);
                    Interlocked.CompareExchange(ref __ShiftLeft, (ShiftDelegate)dyn.CreateDelegate(typeof(ShiftDelegate)), null);
                }
                return __ShiftLeft(value, shift);
            }

            [DebuggerHidden, DebuggerNonUserCode]
            public static T ShiftRightUnsigned(T value, IntPtr shift)
            {
                if (__ShiftRightUnsigned == null)
                {
                    var dyn = new DynamicMethod(@"ShiftRightUnsigned", typeof(T), new Type[] { typeof(T), typeof(IntPtr) }, typeof(T));
                    var gen = dyn.GetILGenerator();
                    gen.Emit(OpCodes.Ldarg_0);
                    gen.Emit(OpCodes.Ldarg_1);
                    gen.Emit(OpCodes.Shr_Un);
                    gen.Emit(OpCodes.Ret);
                    Interlocked.CompareExchange(ref __ShiftRightUnsigned, (ShiftDelegate)dyn.CreateDelegate(typeof(ShiftDelegate)), null);
                }
                return __ShiftRightUnsigned(value, shift);
            }

            [DebuggerHidden, DebuggerNonUserCode]
            public static T Construct()
            {
                if (IsValueType) { return default(T); }
                else
                {
                    if (__Constructor == null)
                    {
                        Type type = typeof(T);
                        var dyn = new DynamicMethod("Constructor", type, null, type, true);
                        var gen = dyn.GetILGenerator();
                        if (type.IsValueType)
                        {
                            gen.Emit(OpCodes.Ldloca_S, (byte)0);
                            gen.Emit(OpCodes.Initobj, type);
                            gen.Emit(OpCodes.Ldloc_0);
                        }
                        else
                        {
                            ConstructorInfo ctor = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null);
                            gen.Emit(OpCodes.Newobj, ctor);
                        }
                        gen.Emit(OpCodes.Ret);
                        Interlocked.CompareExchange(ref __Constructor, (ConstructorDelegate)dyn.CreateDelegate(typeof(ConstructorDelegate)), null);
                    }
                    return __Constructor();
                }
            }

            public delegate T ConstructorDelegate();
            public delegate T ShiftDelegate(T value, IntPtr shift);
        }
    }
    #endregion

    #region Native
    internal static class Native
    {
        public static readonly unsafe memcpyimplDelegate memcpyimpl = (memcpyimplDelegate)Delegate.CreateDelegate(typeof(memcpyimplDelegate), typeof(Buffer).GetMethod("memcpyimpl", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic));
        public static readonly unsafe ZeroMemoryDelegate ZeroMemory = (ZeroMemoryDelegate)Delegate.CreateDelegate(typeof(ZeroMemoryDelegate), typeof(Buffer).GetMethod("ZeroMemory", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic));
        public unsafe delegate void memcpyimplDelegate(byte* src, byte* dest, int len);
        public unsafe delegate void ZeroMemoryDelegate(byte* src, long len);
    }
    #endregion

    #region Marshal Code Generator
    public static class MarshalGen
    {
        private static string GetTypeName(Type type)
        {
            var sb = new System.Text.StringBuilder();
            string className;
            var t = type.IsArray | type.IsPointer | type.IsByRef ? type.GetElementType() : type;
            if (t == typeof(string)) { className = ("string"); }
            else if (t == typeof(sbyte)) { className = ("sbyte"); }
            else if (t == typeof(byte)) { className = ("byte"); }
            else if (t == typeof(short)) { className = ("short"); }
            else if (t == typeof(ushort)) { className = ("ushort"); }
            else if (t == typeof(int)) { className = ("int"); }
            else if (t == typeof(uint)) { className = ("uint"); }
            else if (t == typeof(long)) { className = ("long"); }
            else if (t == typeof(ulong)) { className = ("ulong"); }
            else if (t == typeof(IntPtr)) { className = ("IntPtr"); }
            else if (t == typeof(UIntPtr)) { className = ("UIntPtr"); }
            else if (t == typeof(decimal)) { className = ("decimal"); }
            else if (t == typeof(bool)) { className = ("bool"); }
            else { className = t.Name; }
            if (type.IsArray) { className += "[]"; }
            if (type.IsPointer) { className += "*"; }
            sb.Append(className);
            return sb.ToString();
        }

        private static string GetTypeNestedName(Type info) { return string.IsNullOrEmpty(info.Namespace) ? info.FullName : info.FullName.Substring(info.Namespace.Length + 1); }

        public static string IdentifierToAllCaps(string identifier)
        {
            var sb = new System.Text.StringBuilder(identifier.Length);
            for (int i = 0; i < identifier.Length; i++)
            {
                if (char.IsUpper(identifier, i) && i > 0 && ((i < identifier.Length - 1 && char.IsLower(identifier, i + 1)) || char.IsLower(identifier, i - 1)))
                {
                    sb.Append('_');
                }
                sb.Append(char.ToUpper(identifier[i]));
            }
            return sb.ToString();
        }

        private static readonly string DOUBLE_OPEN_BRACE = "{{";
        private static readonly string DOUBLE_CLOSE_BRACE = "}}";

        public static string GenerateMarshalCode(Type type) //Assumes bytes not marshaled are not necessarily zero
        {
            var sb = new System.Text.StringBuilder();
            var offsets = new List<string>();
            var marshalFrom = new List<string>();
            var marshalTo = new List<string>();
            foreach (var field in type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
            {
                var offsetName = IdentifierToAllCaps(field.Name).TrimStart('_') + "_OFFSET";
                offsets.Add("[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
                offsets.Add(string.Format("private static readonly IntPtr {0} = Marshal.OffsetOf(typeof({1}), {2});", offsetName, GetTypeNestedName(type), '"' + field.Name + '"'));

                var marshalAs = (System.Runtime.InteropServices.MarshalAsAttribute)Attribute.GetCustomAttribute(field, typeof(System.Runtime.InteropServices.MarshalAsAttribute));

                if (field.FieldType.IsValueType && Marshaler.IsBlittableSlow(field.FieldType))
                { marshalFrom.Add(string.Format("this.{0} = buffer.Read<{1}>({2});", field.Name, GetTypeName(field.FieldType), offsetName)); }
                else if (field.FieldType == typeof(string))
                {
                    if (marshalAs != null && marshalAs.Value == System.Runtime.InteropServices.UnmanagedType.ByValTStr)
                    { marshalFrom.Add(string.Format("this.{0} = buffer.ToString{1}((int){2}, {3});", field.Name, (type.Attributes & (TypeAttributes.UnicodeClass | TypeAttributes.AutoClass)) != 0 ? "Uni" : "Ansi", offsetName, marshalAs.SizeConst)); }
                    else { marshalFrom.Add(string.Format("throw new NotImplementedException(\"String marshal type of {0} not supported.\"); //this.{0} = Marshaler.PtrToStructure<{1}>(buffer.ExtractSegment({2}));", field.Name, GetTypeName(field.FieldType), offsetName)); }
                }
                else if (field.FieldType.IsArray && field.FieldType.GetElementType().IsPrimitive)
                {
                    if (marshalAs != null && marshalAs.Value == System.Runtime.InteropServices.UnmanagedType.ByValArray)
                    {
                        marshalFrom.Add(string.Format("this.{0} = new {1}[{2}];", field.Name, GetTypeName(field.FieldType.GetElementType()), marshalAs.SizeConst));
                        marshalFrom.Add(string.Format("buffer.CopyTo((int){0}, this.{1}, 0, this.{1}.Length);", offsetName, field.Name));
                    }
                    else { marshalFrom.Add(string.Format("throw new NotImplementedException(\"Array marshal type of {0} not supported.\");", field.Name, GetTypeName(field.FieldType), offsetName)); }
                }
                else
                { marshalFrom.Add(string.Format("this.{0} = Marshaler.PtrToStructure<{1}>(buffer.ExtractSegment({2}));", field.Name, GetTypeName(field.FieldType), offsetName)); }


                if (field.FieldType.IsValueType && Marshaler.IsBlittableSlow(field.FieldType))
                { marshalTo.Add(string.Format("buffer.Write(this.{0}, {1});", field.Name, offsetName)); }
                else if (field.FieldType == typeof(string))
                { marshalTo.Add(string.Format("throw new NotImplementedException(\"String marshal type of {0} not supported.\"); //Marshaler.StructureToPtr(this.{0}, buffer.ExtractSegment({1}));", field.Name, offsetName)); }
                else if (field.FieldType.IsArray && field.FieldType.GetElementType().IsPrimitive)
                {
                    if (marshalAs != null && marshalAs.Value == System.Runtime.InteropServices.UnmanagedType.ByValArray)
                    {
                        marshalTo.Add(string.Format("if (this.{0}.Length > {1}) " + DOUBLE_OPEN_BRACE + " throw new OverflowException(\"Field is too large.\"); " + DOUBLE_CLOSE_BRACE + "", field.Name, marshalAs.SizeConst));
                        marshalTo.Add(string.Format("buffer.CopyFrom((int){0}, this.{1}, 0, this.{1}.Length);", offsetName, field.Name, marshalAs.SizeConst));
                        marshalTo.Add(string.Format("buffer.Initialize((int){0} + this.{1}.Length, {2} - this.{1}.Length);", offsetName, field.Name, marshalAs.SizeConst));
                    }
                    else { marshalTo.Add(string.Format("throw new NotImplementedException(\"Array marshal type of {0} not supported.\");", field.Name, GetTypeName(field.FieldType), offsetName)); }
                }
                else
                { marshalTo.Add(string.Format("Marshaler.StructureToPtr(this.{0}, buffer.ExtractSegment({1}));", field.Name, offsetName)); }
            }

            sb.AppendLine(string.Format("{0} {1} : IMarshalable", type.IsClass ? "class" : "struct", type.Name));
            sb.AppendLine("{");
            foreach (var offset in offsets)
            {
                sb.AppendLine(string.Format("\t{0}", offset));
            }

            sb.AppendLine();

            sb.AppendLine("\tprotected override void MarshalFrom(BufferWithSize buffer)");
            sb.AppendLine("\t{");
            sb.AppendLine("\t\tbase.MarshalFrom(buffer);");
            foreach (var marshal in marshalFrom) { sb.AppendLine(string.Format("\t\t{0}", marshal)); }
            sb.AppendLine("\t}");

            sb.AppendLine();

            sb.AppendLine("\tprotected override void MarshalTo(BufferWithSize buffer)");
            sb.AppendLine("\t{");
            sb.AppendLine("\t\tbase.MarshalTo(buffer);");
            foreach (var marshal in marshalTo) { sb.AppendLine(string.Format("\t\t{0}", marshal)); }
            sb.AppendLine("\t}");

            sb.AppendLine();

            offsets.Add("\t[DebuggerBrowsable(DebuggerBrowsableState.Never)]");
            sb.AppendLine(string.Format("\tprotected override int MarshaledSize " + DOUBLE_OPEN_BRACE + " get " + DOUBLE_OPEN_BRACE + " return Marshaler.DefaultSizeOf<{0}>(); " + DOUBLE_CLOSE_BRACE + " " + DOUBLE_CLOSE_BRACE + "", type.Name));

            sb.AppendLine("}");
            return sb.ToString();
        }
    }
    #endregion

    #region Bits
    public static class Bits
    {
        public static T BigEndian<T>(T value) { return BitConverter.IsLittleEndian ? ReverseBytes(value) : value; }
        public static T LittleEndian<T>(T value) { return BitConverter.IsLittleEndian ? value : ReverseBytes(value); }

        public static T GetValueMask<T>(T source, int valueLeftShift, T mask)
        {
            unsafe
            {
                var size = Objects.SizeOf<T>();
                var tr = __makeref(source);
                var sourceBuffer = new BufferWithSize(((IntPtr*)(&tr))[0], size);
                tr = __makeref(mask);
                var maskBuffer = new BufferWithSize(((IntPtr*)(&tr))[0], size);
                for (uint i = 0; i < size; i++)
                { sourceBuffer[i] &= maskBuffer[i]; }

                return Objects.ShiftRightUnsigned<T>(source, (IntPtr)valueLeftShift);
            }

            //return (source & mask) >> valueLeftShift;
        }

        public static T PutValueMask<T>(T target, T value, int valueLeftShift, T mask)
        {
            unsafe
            {
                value = Objects.ShiftLeft(value, (IntPtr)valueLeftShift);

                var size = Objects.SizeOf<T>();
                var tr = __makeref(target);
                var targetBuffer = new BufferWithSize(((IntPtr*)(&tr))[0], size);
                tr = __makeref(value);
                var valueBuffer = new BufferWithSize(((IntPtr*)(&tr))[0], size);
                tr = __makeref(mask);
                var maskBuffer = new BufferWithSize(((IntPtr*)(&tr))[0], size);
                for (uint i = 0; i < size; i++)
                {
                    targetBuffer[i] &= unchecked((byte)~maskBuffer[i]);
                    valueBuffer[i] &= maskBuffer[i];
                    targetBuffer[i] |= valueBuffer[i];
                }
                return target;
            }
        }

        public static T ReverseBytes<T>(T value)
        {
            unsafe
            {
                var tr = __makeref(value);
                var valueBuffer = new BufferWithSize(((IntPtr*)(&tr))[0], Objects.SizeOf<T>());
                for (uint i = 0; i < valueBuffer.LengthU32 >> 1; i++)
                {
                    byte b = valueBuffer[i];
                    valueBuffer[i] = valueBuffer[valueBuffer.LengthU32 - i - 1];
                    valueBuffer[valueBuffer.LengthU32 - i - 1] = b;
                }
                return value;
            }
        }

        public static bool GetBit<T>(T value, int i)
        {
            var size = Objects.SizeOf<T>();
            var tr = __makeref(value);
            unsafe
            {
                var sourceBuffer = new BufferWithSize(((IntPtr*)(&tr))[0], size);
                return (sourceBuffer[i / 8] & (1 << (i % 8))) != 0;
            }
        }

        public static T SetBit<T>(T value, int i, bool bit)
        {
            var size = Objects.SizeOf<T>();
            var tr = __makeref(value);
            unsafe
            {
                var sourceBuffer = new BufferWithSize(((IntPtr*)(&tr))[0], size);
                if (bit) { sourceBuffer[i / 8] |= unchecked((byte)(1 << (i % 8))); }
                else { sourceBuffer[i / 8] &= unchecked((byte)(~(1 << (i % 8)))); }
            }
            return value;
        }
    }
    #endregion

    /// <summary>Specifies whether a class or structure is blittable, preventing the need destination perform a slow check during runtime.</summary>
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class BlittableAttribute : Attribute { private bool blittable; public BlittableAttribute(bool blittable) { this.blittable = blittable; } public bool Blittable { get { return this.blittable; } } }
}
#pragma warning restore 3021