using System.Diagnostics;
using SDL2;

class Program
{
    static nint window;
    static nint renderer;
    static nint texture;
    static Chip8.Chip8 cpu;

    static void Main(string[] args)
    {
        try
        {
            Init();

            cpu = new Chip8.Chip8();
            cpu.Init();

            //TODO: Load ROM


            bool keepRunning = true;
            while(keepRunning)
            {
                //TODO: Emulator cycle
                SDL.SDL_Event ev;
                while (SDL.SDL_PollEvent(out ev) != 0)
                {
                    if (ev.type == SDL.SDL_EventType.SDL_QUIT)
                    {
                        keepRunning = false;
                    }
                }

                // render the screen
                _ = SDL.SDL_RenderClear(renderer);

                //TODO: Build the texture

                _ = SDL.SDL_RenderCopy(renderer, texture, IntPtr.Zero, IntPtr.Zero);
                SDL.SDL_RenderPresent(renderer);

                // 16 Hz running
                Thread.Sleep(16);
                
            }

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