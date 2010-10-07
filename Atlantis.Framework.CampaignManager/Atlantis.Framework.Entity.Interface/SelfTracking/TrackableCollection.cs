using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization; 

namespace Atlantis.Framework.Entity.Interface.SelfTracking
{
    /// <summary>
    /// An System.Collections.ObjectModel.ObservableCollection that raises
    /// individual item removal notifications on clear and prevents adding duplicates.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TrackableCollection<T> : ObservableCollection<T>
    {
        protected override void ClearItems()
        {
            new List<T>(this).ForEach(t => Remove(t));
        }

        protected override void InsertItem(int index, T item)
        {
            if (!this.Contains(item))
            {
                base.InsertItem(index, item);
            }
        }
    }
}
