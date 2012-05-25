#region using

using System;
using System.Collections;
using System.Collections.Generic;

#endregion

namespace Negar.PersianCalendar.UI.BaseClasses
{
    /// <summary>
    /// كلاس مدیریت مجموعه ای از تاریخ ها
    /// </summary>
    public class DateTimeCollection : IList<DateTime>
    {
        #region Events

        /// <summary>
        /// Raised when the collection is changed.
        /// </summary>
        public event EventHandler<CollectionChangedEventArgs> CollectionChanged;

        #endregion

        #region Fields

        private readonly List<DateTime> _Data = new List<DateTime>();

        #endregion

        #region Protected Methods

        /// <summary>
        /// Fires CollectionChanged event.
        /// </summary>
        protected virtual void OnCollectionChanged(CollectionChangedEventArgs e)
        {
            if (CollectionChanged != null) CollectionChanged(this, e);
        }

        #endregion

        #region Public Methods

        #region public void Add(DateTime item)

        public void Add(DateTime item)
        {
            _Data.Add(item);
            OnCollectionChanged(new CollectionChangedEventArgs(CollectionChangeType.Add));
        }

        #endregion

        #region public void AddRange(DateTime[] items)

        public void AddRange(DateTime[] items)
        {
            _Data.AddRange(items);
            OnCollectionChanged(new CollectionChangedEventArgs(CollectionChangeType.Add));
        }

        #endregion

        #region public void Clear()

        public void Clear()
        {
            _Data.Clear();
            OnCollectionChanged(new CollectionChangedEventArgs(CollectionChangeType.Clear));
        }

        #endregion

        #region public Boolean Contains(DateTime item)

        public Boolean Contains(DateTime item)
        {
            return _Data.Contains(item);
        }

        #endregion

        #region public void CopyTo(DateTime[] array, Int32 arrayIndex)

        public void CopyTo(DateTime[] array, Int32 arrayIndex)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region public Int32 Count

        public Int32 Count
        {
            get { return _Data.Count; }
        }

        #endregion

        #region public Boolean IsReadOnly

        public Boolean IsReadOnly
        {
            get { return false; }
        }

        #endregion

        #region public Boolean Remove(DateTime item)

        public Boolean Remove(DateTime item)
        {
            Boolean result = _Data.Remove(item);
            if (result) OnCollectionChanged(new CollectionChangedEventArgs(CollectionChangeType.Remove));
            return result;
        }

        #endregion

        #region public void RemoveAt(Int32 index)

        public void RemoveAt(Int32 index)
        {
            _Data.RemoveAt(index);
            OnCollectionChanged(new CollectionChangedEventArgs(CollectionChangeType.Remove));
        }

        #endregion

        #region public void RemoveAll(Predicate<DateTime> match)

        public void RemoveAll(Predicate<DateTime> match)
        {
            _Data.RemoveAll(match);
            OnCollectionChanged(new CollectionChangedEventArgs(CollectionChangeType.Remove));
        }

        #endregion

        #region public DateTime this[Int32 index]

        public DateTime this[Int32 index]
        {
            get { return _Data[index]; }
            set
            {
                _Data[index] = value;
                OnCollectionChanged(new CollectionChangedEventArgs(CollectionChangeType.Other));
            }
        }

        #endregion

        #region public IEnumerator<DateTime> GetEnumerator()

        public IEnumerator<DateTime> GetEnumerator()
        {
            return _Data.GetEnumerator();
        }

        #endregion

        #region IEnumerator IEnumerable.GetEnumerator()

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Data.GetEnumerator();
        }

        #endregion

        #region public Int32 IndexOf(DateTime item)

        public Int32 IndexOf(DateTime item)
        {
            return _Data.IndexOf(item);
        }

        #endregion

        #region public void Insert(Int32 index, DateTime item)

        public void Insert(Int32 index, DateTime item)
        {
            _Data.Insert(index, item);
            OnCollectionChanged(new CollectionChangedEventArgs(CollectionChangeType.Add));
        }

        #endregion

        #endregion
    }
}