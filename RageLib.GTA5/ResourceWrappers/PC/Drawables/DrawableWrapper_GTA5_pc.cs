/*
    Copyright(c) 2015 Neodymium

    Permission is hereby granted, free of charge, to any person obtaining a copy
    of this software and associated documentation files (the "Software"), to deal
    in the Software without restriction, including without limitation the rights
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
    copies of the Software, and to permit persons to whom the Software is
    furnished to do so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in
    all copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
    THE SOFTWARE.
*/

using System;
using System.Collections;
using System.Collections.Generic;
using RageLib.Resources.GTA5.PC.Drawables;
using RageLib.ResourceWrappers.Drawables;

namespace RageLib.GTA5.ResourceWrappers.PC.Drawables
{
    public class DrawableListWrapper_GTA5_pc : IDrawableList
    {
        private IList<GtaDrawable> list;

        public DrawableListWrapper_GTA5_pc(IList<GtaDrawable> list)
        {
            this.list = list;
        }


        public IDrawable this[int index]
        {
            get
            {
                return new DrawableWrapper_GTA5_pc(list[index]);
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

        public void Add(IDrawable item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(IDrawable item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(IDrawable[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IDrawable> GetEnumerator()
        {
            foreach (var x in list)
                yield return new DrawableWrapper_GTA5_pc(x);
        }

        public int IndexOf(IDrawable item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, IDrawable item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(IDrawable item)
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

    public class DrawableWrapper_GTA5_pc : IDrawable
    {
        private GtaDrawable drawable;

        public IShaderGroup ShaderGroup
        {
            get
            {
                if (drawable.ShaderGroup != null)
                    return new ShaderGroupWrapper_GTA5_pc(drawable.ShaderGroup);
                else
                    return null;
            }
        }

        public string Name
        {
            get
            {
                return (string)drawable.Name;
            }
        }

        public DrawableWrapper_GTA5_pc(GtaDrawable drawable)
        {
            this.drawable = drawable;
        }
    }
}
