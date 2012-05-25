using System;
using System.Collections.Generic;
using System.Collections;

namespace Helper.Collections
{
	public class WeakDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
	{
		protected IDictionary<TKey, WeakReference> Dictionary { get; private set; }
		public WeakDictionary() : this(typeof(IComparable<TKey>).IsAssignableFrom(typeof(TKey)) ? (IDictionary<TKey, WeakReference>)new SortedDictionary<TKey, WeakReference>() : new Dictionary<TKey, WeakReference>()) { }
		public WeakDictionary(IDictionary<TKey, WeakReference> wrappedDictionary) { this.Dictionary = wrappedDictionary; }
		public bool TryGetValue(TKey key, out TValue value) { WeakReference weakRef; if (this.Dictionary.TryGetValue(key, out weakRef)) { var target = weakRef.Target; if (target != null) { value = (TValue)target; return true; } else { this.Dictionary.Remove(key); } } value = default(TValue); return false; }
		public TValue TryGetValue(TKey key) { TValue value; if (this.TryGetValue(key, out value)) { return value; } else { return default(TValue); } }
		public TValue this[TKey key] { get { TValue value; if (!this.TryGetValue(key, out value)) { throw new KeyNotFoundException(); } return value; } set { this.Dictionary[key] = new WeakReference(value); } }
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() { ICollection<TKey> itemsToRemove = null; foreach (var pair in this.Dictionary) { var target = pair.Value.Target; if (target != null) { yield return new KeyValuePair<TKey, TValue>(pair.Key, (TValue)target); } else { if (itemsToRemove == null) { itemsToRemove = new List<TKey>(); } itemsToRemove.Add(pair.Key); } } if (itemsToRemove != null) { foreach (var key in itemsToRemove) { this.Dictionary.Remove(key); } } }	
		IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
		public void TrimToSize() { ICollection<TKey> itemsToRemove = null; foreach (var pair in this.Dictionary) { var target = pair.Value.Target; if (target == null && itemsToRemove == null) { itemsToRemove = new List<TKey>(); itemsToRemove.Add(pair.Key); } } if (itemsToRemove != null) { foreach (var key in itemsToRemove) { this.Dictionary.Remove(key); } } }
		public bool Remove(TKey key) { return this.Dictionary.Remove(key); }
	}
}