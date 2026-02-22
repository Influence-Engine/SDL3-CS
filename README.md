# SDL3 Sharp - Deliberately Designed SDL3 Bindings for C#

A modern, clean, and "simplified" binding for [SDL3 (Simple DirectMedia Layer 3)](https://github.com/libsdl-org/SDL) specifically designed for C# project development. This binding prioritizes developer experience by reducing verbosity while maintaining SDL3 functionality.

## Key Features
**Hand-Written, Not Generated:** Every binding is manually crafted and verified, ensuring:
- Clean, consistent code quality
- Deliberate design decisions
- Human Error (Only human error)

**Development-Driven Implentation:**
- Functions are implenented based on "real" project needs
- Priorited implementation of most commonly used features
- Continuous expansion based on project requirements

**Simplified Naming Convention:** Eliminates redundant SDL prefixes for cleaner code
```cs
// Traditional SDL binding
SDL.SDL_Init(SDL.SDL_InitFlags.SDL_INIT_VIDEO)
bool isFullscreen => ((SDL.SDL_WindowFlags)SDL.SDL_GetWindowFlags(windowHandle) & SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN) != 0;

// Our binding
SDL.Init(SDL.InitFlags.Video)
bool isFullscreen => ((SDL.WindowFlags)SDL.GetWindowFlags(windowHandle) & SDL.WindowFlags.Fullscreen) != 0;
```

**Up-to-date:** (Not at all >.<) 

## Current Implementation Status
This binding is actively being developed alongside some projects, with features being implemented based on pracitical needs.  
Currently implemented features include:
- Core initialization and setup
- Window management
- Rendering system
- A lot of sprinkles here and there  
 
Custom implementations include:  
- RenderCircle (Draw a simple filled circle O.o) uses RenderGeometry "under the hood"
- Constructors (To make random things like FColor just a little more conveniant) cause I hate doing it over and over again

***Note:*** *Not all SDL3 functions are currently implemented. Features are being added based on development priorities and engine requirements.*

## Quick Start
```cs
using SDL3;

class Programm
{
  static void Main()
  {
    // Initialize SDL
    SDL.Init(SDL.InitFlags.Video);

    // Create flags for window creation
    SDL.WindowFlags flags = new SDL.WindowFlags();

    // Create window and renderer
    IntPtr window = SDL.CreateWindow("SDL3 Demo", 800, 600, flags);
    IntPtr renderer = SDL.CreateRenderer(window, null);

    // Game loop
    while(true)
    {
      while(SDL.PollEvent(out SDL.Event e))
      {
        if(e.type == SDL.EventType.Quit)
          return;
      }

      // Render
      SDL.SetRenderDrawColor(renderer, 0, 0, 0, 255);
      SDL.RenderClear(renderer);
      SDL.RenderPresent(renderer);
    }
  }
}
```

## License
This project is licenense under [MIT license](LICENSE).  

## Acknowledgements
- SDL3 development team and contributors for the excellent multimedia library  
  
  
*Can you find all the spelling mistakes? Cause I still find them...*  
"Will I do this again if SDL4 drops... yes, yes I will"  