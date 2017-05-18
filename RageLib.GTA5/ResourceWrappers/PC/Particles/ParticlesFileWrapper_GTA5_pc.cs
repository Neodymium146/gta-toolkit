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

using RageLib.Resources.GTA5;
using RageLib.Resources.GTA5.PC.Particles;
using RageLib.ResourceWrappers.Particles;
using System;
using System.IO;

namespace RageLib.GTA5.ResourceWrappers.PC.Particles
{
    public class ParticlesFileWrapper_GTA5_pc : IParticlesFile
    {
        private ParticleEffectsList particles;

        public IParticles Particles
        {
            get
            {
                return new ParticlesWrapper_GTA5_pc(particles);
            }
        }

        public void Load(string fileName)
        {
            var resource = new ResourceFile_GTA5_pc<ParticleEffectsList>();
            resource.Load(fileName);

            particles = resource.ResourceData;
        }

        public void Save(string fileName)
        {
            var resource = new ResourceFile_GTA5_pc<ParticleEffectsList>();
            resource.ResourceData = particles;
            resource.Version = 68;
            resource.Save(fileName);
        }

        public void Load(Stream stream)
        {
            var resource = new ResourceFile_GTA5_pc<ParticleEffectsList>();
            resource.Load(stream);

            if (resource.Version != 68)
                throw new Exception("version error");

            particles = resource.ResourceData;
        }

        public void Save(Stream stream)
        {
            var resource = new ResourceFile_GTA5_pc<ParticleEffectsList>();
            resource.ResourceData = particles;
            resource.Version = 68;
            resource.Save(stream);
        }
    }
}