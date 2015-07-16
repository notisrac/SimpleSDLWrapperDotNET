using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SimpleSDLWrapperDotNET.Mixer
{
    /// <summary>
    /// A simple multi-channel audio mixer for SDL
    /// </summary>
    public class SDLMixerWrapper : IDisposable
    {
        public static readonly int DEFAULT_FREQUENCY = SDL_mixer.MIX_DEFAULT_FREQUENCY;
        public static readonly ushort DEFAULT_FORMAT = SDL_mixer.MIX_DEFAULT_FORMAT;
        public static readonly int DEFAULT_SAMPLESIZE = 2048;

        private bool disposed = false;
        private bool _bDecodersInitialized = false;
        private bool _bAudioInitialized = false;

        public SDLMixerWrapper()
        { }

        /// <summary>
        /// Initialize the mixer API with the default and recommended values.
        /// This must be called before using other functions in this library.
        /// </summary>
        public void Initialize()
        {
            Initialize(DEFAULT_FREQUENCY, DEFAULT_FORMAT, Channels.STEREO, DEFAULT_SAMPLESIZE);
        }

        /// <summary>
        /// Initialize the mixer API.
        /// This must be called before using other functions in this library.
        /// </summary>
        /// <param name="frequency">Output sampling frequency in samples per second (Hz). You might use DEFAULT_FREQUENCY(22050) since that is a good value for most games. </param>
        /// <param name="audioFormat">Output sample format.</param>
        /// <param name="channels">Number of sound channels in output. Set to Channels.STEREO(2) for stereo, Channels.MONO(1) for mono. This has nothing to do with mixing channels. </param>
        /// <param name="sampleSize">Bytes used per output sample.</param>
        public void Initialize(int frequency, ushort audioFormat, Channels channels, int sampleSize)
        {
            int iResult = SDL_mixer.Mix_OpenAudio(frequency, audioFormat, (int)channels, sampleSize);
            if (0 != iResult)
            {
                throw new Exception("Error while trying to initialize SDL_mixer: " + SDL.SDL_GetError());
            }
            _bAudioInitialized = true;
        }

        public void InitializeDecoders()
        {
            throw new NotImplementedException();
            _bDecodersInitialized = true;
        }

        public AudioSample LoadSample(string fileName)
        {
            return new AudioSample(fileName);
        }

        /// <summary>
        /// Set the number of channels being mixed. 
        /// </summary>
        /// <param name="numberOfChannels">Number of channels to allocate for mixing.</param>
        /// <returns>The number of channels allocated.</returns>
        public int AllocateChannels(int numberOfChannels)
        {
            int iNumberOfChannelsAllocated = SDL_mixer.Mix_AllocateChannels(numberOfChannels);
            return iNumberOfChannelsAllocated;
        }

        /// <summary>
        /// Gets the number of channels being mixed. 
        /// </summary>
        /// <returns>The number of channels allocated.</returns>
        public int GetAllocatedChannels()
        {
            return AllocateChannels(-1);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                //SDL_mixer.Mix_CloseAudio(); // needed when the audio functions are initialized with mix_openaudio
                SDL_mixer.Mix_Quit(); // - only needed when decoders were loaded with mix_init
            }

            disposed = true;
        }

        ~SDLMixerWrapper()
        {
            Dispose(false);
        }
    }
}
