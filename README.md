# SimpleSDLWrapperDotNET
Based on [flibitijibibo's SDL2-CS](https://github.com/flibitijibibo/SDL2-CS), it is a really simple wrapper for SDL2 and SDL2.mixer for the .NET framework.
Initially it was created for my CHIP-8 emulator. So currently it only implements the features needed for that:
* Creating a window
* Creating and displaying a texture
* Playing wave files (samples)
* Handling keyboard input

## Usage
### Creating a window
Creates a 640x320 pixels window at 100x100 with the title `"Test window"`
```c#
  SDLWrapper sdl = new SDLWrapper();
  sdl.Initialize();
  sdl.CreateWindow("Test window", 100, 100, 640, 320, WindowFlags.WINDOW_SHOWN);
  sdl.CreateRenderer(SDLWrapper.DEFAULT_RENDERING_DRIVER, RendererFlags.RENDERER_ACCELERATED);
```

You also need to do a loop to constantly render the screen and handle the events.
In order to be able to close the window you must handle the OnQuit event, in which you simply need to end the loop
```c#
  sdl.OnQuit += sdl_onQuit;
  bRunning = true;
  while (bRunning)
  {
    // call this at the beginning of ever loop to capture the events
    sdl.HandleEvents();

    sdl.ClearScreen();
    sdl.Render();
  }

  static void sdl_onQuit(object sender, EventArgs e)
  {
      bRunning = false;
  }
```


### Creating a texture
Create a 64x32 pixel texture. This will be a dynamic texture, meaning that it's pixels can be changed from code.
```c#
  Texture txDisplayTexture = sdl.CreateDynamicTexture(64, 32);
```
Fill and render the texture:
```c#
  // create an array for the pixel data
  Color[] caPixelPile = new Color[64 * 32];
  for (int i = 0; i < caPixelPile.Length; i++)
  { // fill it with random pixels
      caPixelPile[i] = new Color(rndRandom.Next(255), rndRandom.Next(255), rndRandom.Next(255), rndRandom.Next(255));
  }
  // before accessing the texture we need to lock it
  txDisplayTexture.Lock();
  // copy the pixel data from the array into the texture
  txDisplayTexture.SetPixels(caPixelPile);
  // indicate that we are done writing to the texture
  txDisplayTexture.Unlock();

  sdl.ClearScreen();
  // render the texture on the screen
  sdl.RenderTexture(txDisplayTexture);
```


### Handling key presses
Subscribe to the key pressed and released events:
```c#
  sdl.OnKeyPressed += sdl_OnKeyPressedOrReleased;
  sdl.OnKeyReleased += sdl_OnKeyPressedOrReleased;
```
And handle them:
```c#
  static void sdl_OnKeyPressedOrReleased(object sender, KeyboardEventArgs e)
  {
      if (null != e)
      {
          if (e.KeyInfo.Scancode == KeyScancode.A && e.State == KeyState.PRESSED)
          {
              // do something
          }
          else if (e.KeyInfo.Scancode == KeyScancode.NumPadPlus && e.State == KeyState.PRESSED)
          {
              // do something else
          }
      }
  }
```


### Playing an audio sample
To play audio samples (note: not a music file, just a sample), just instantiate the SDL.mixer, and load an audio file:
```c#
  SDLMixerWrapper mixer = new SDLMixerWrapper();
  mixer.Initialize();
  sample = mixer.LoadSample(@"Ding.wav");
```
Then all you need to do is call play on it:
```c#
  sample.Play();
```


### Sample
Check the TestApp for a complete sample!
