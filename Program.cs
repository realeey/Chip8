using System.Diagnostics;
using SDL2;

class Program
{
    static nint window;
    static nint renderer;
    static nint texture;

    static void Main(string[] args)
    {
        try
        {
            Init();
        }
        finally
        {
            Deinit();
        }
    }

    static void Init()
    {
        if(SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
        {
            throw new ("SDL Init Error");
        }

        window = SDL.SDL_CreateWindow("Chip 8", SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED, 1024, 512, 0);

        if(window == IntPtr.Zero)
        {
            throw new("Window Creation Error");
        }

        renderer = SDL.SDL_CreateRenderer(window, -1, 0);

        if (renderer == IntPtr.Zero)
        {
            throw new("Renderer Creation Error");
        }

        texture = SDL.SDL_CreateTexture(renderer, SDL.SDL_PIXELFORMAT_RGBA8888, (int) SDL.SDL_TextureAccess.SDL_TEXTUREACCESS_STREAMING, 64,32);

    }

    static void Deinit()
    {
        SDL.SDL_DestroyWindow(window);
        SDL.SDL_Quit();
    }

}