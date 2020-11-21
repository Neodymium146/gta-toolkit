using RageLib.Resources.GTA5.PC.Bounds;
using RageLib.ResourceWrappers.Bounds;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RageLib.GTA5.ResourceWrappers.PC.Bounds
{
    public class BoundWrapper_GTA5_pc : IBound
    {
        private Bound bound;

        public BoundWrapper_GTA5_pc(Bound bound)
        {
            this.bound = bound;
        }
    }

    public class BoundListWrapper_GTA5_pc : IBoundList
    {
        private IList<Bound> list;

        public BoundListWrapper_GTA5_pc(IList<Bound> list)
        {
            this.list = list;
        }


        public IBound this[int index]
        {
            get
            {
                return new BoundWrapper_GTA5_pc(list[index]);
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(IBound item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(IBound item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(IBound[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IBound> GetEnumerator()
        {
            foreach (var x in list)
                yield return new BoundWrapper_GTA5_pc(x);
        }

        public int IndexOf(IBound item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, IBound item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IBound item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}