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

using RageLib.Resources.GTA5.PC.Particles;
using RageLib.ResourceWrappers;
using RageLib.ResourceWrappers.GTA5.PC.Textures;
using RageLib.ResourceWrappers.Particles;

namespace RageLib.GTA5.ResourceWrappers.PC.Particles
{
    public class ParticlesWrapper_GTA5_pc : IParticles
    {
        private ParticleFile_GTA5_pc particles;

        public ITextureDictionary TextureDictionary
        {
            get
            {
                if (particles.TextureDictionary != null)
                    return new TextureDictionaryWrapper_GTA5_pc(particles.TextureDictionary);
                else
                    return null;
            }
        }

        public ParticlesWrapper_GTA5_pc(ParticleFile_GTA5_pc particles)
        {
            this.particles = particles;
        }
    }
}