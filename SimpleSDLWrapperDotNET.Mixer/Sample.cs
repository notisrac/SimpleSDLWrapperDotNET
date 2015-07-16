using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;
using System.IO;

namespace SimpleSDLWrapperDotNET.Mixer
{
    /// <summary>
    /// The format for an audio sample chunk. This stores the filename, the length in bytes of that data, and the volume to use when mixing the sample. 
    /// </summary>
    public class AudioSample
    {
        /// <summary>
        /// Length of the audiosample file in bytes
        /// </summary>
        public int Length { get; private set; }
        /// <summary>
        /// The volume of the sample
        /// </summary>
        public int Volume
        {
            get { return GetVolume(); }
            set { SetVolume(value); }
        }
        /// <summary>
        /// The filename of the sample
        /// </summary>
        public string FileName { get; private set; }
        public IntPtr Handle { get; private set; }

        private bool disposed = false;

        /// <summary>
        /// Creates a new audiosample from the audio file.
        /// This can load WAVE, AIFF, RIFF, OGG, and VOC files.
        /// </summary>
        /// <param name="fileName">The filename of the sample</param>
        public AudioSample(string fileName)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException("Audio sample file \"" + fileName + "\" was not found!");
            }
            FileName = fileName;
            Length = File.ReadAllBytes(fileName).Length;
            // load the chunk
            Handle = SDL_mixer.Mix_LoadWAV(fileName);
            if (IntPtr.Zero == Handle)
            {
                throw new Exception("Error while trying to load the audio sample file \"" + fileName + "\": " + SDL.SDL_GetError());
            }
        }

        /// <summary>
        /// Gets the volume of this audiosample (chunk)
        /// Previous chunk->volume setting. If you passed a negative value for volume then this volume is still the current volume for the chunk. 
        /// </summary>
        private int GetVolume()
        {
            return SDL_mixer.Mix_VolumeChunk(Handle, -1);
        }

        /// <summary>
        /// Set chunk->volume to volume.
        /// The volume setting will take effect when the chunk is used on a channel, being mixed into the output. 
        /// </summary>
        /// <param name="volume">The volume to use from 0 to MIX_MAX_VOLUME(128). If greater than MIX_MAX_VOLUME, then it will be set to MIX_MAX_VOLUME. If less than 0 then chunk->volume will not be set.</param>
        private void SetVolume(int volume)
        {
            SDL_mixer.Mix_VolumeChunk(Handle, volume);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Play this sample on the first available audio channel
        /// </summary>
        /// <returns>The channel the sample is played on</returns>
        public int Play()
        {
            return Play(0);
        }

        /// <summary>
        /// Play this sample looped on the first available audio channel
        /// </summary>
        /// <param name="loops">Number of loops, -1 is infinite loops. Passing one here plays the sample twice (1 loop). </param>
        /// <returns>The channel the sample is played on</returns>
        public int Play(int loops)
        {
            int iChannelNumber = SDL_mixer.Mix_PlayChannel(-1, Handle, loops);
            if (-1 == iChannelNumber)
            {
                string sErrorMessage = SDL.SDL_GetError();
                if (!sErrorMessage.Contains("No free channels available"))
                {
                    throw new Exception("Error while trying to play the audio sample file \"" + FileName + "\": " + sErrorMessage);
                }
            }
            return iChannelNumber;
        }


        protected void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                SDL_mixer.Mix_FreeChunk(Handle);
                Handle = IntPtr.Zero;
            }

            disposed = true;
        }

        ~AudioSample()
        {
            Dispose(false);
        }

    }
}
