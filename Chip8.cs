using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8
{
    internal class Chip8
    {

        ushort opcode;
        byte[] memory = new byte[4096];
        byte[] graphics = new byte[64 * 32];
        byte[] registers = new byte[16];
        ushort index;
        ushort programCounter;

        byte delayTimer;
        byte soundTimer;

        ushort[] stack = new ushort[16];
        ushort stackPointer;

        byte[] keys = new byte[16];

        byte[] chip8_fontset =
        {
            0xF0, 0x90, 0x90, 0x90, 0xF0, // 0
            0x20, 0x60, 0x20, 0x20, 0x70, // 1
            0xF0, 0x10, 0xF0, 0x80, 0xF0, // 2
            0xF0, 0x10, 0xF0, 0x10, 0xF0, // 3
            0x90, 0x90, 0xF0, 0x10, 0x10, // 4
            0xF0, 0x80, 0xF0, 0x10, 0xF0, // 5
            0xF0, 0x80, 0xF0, 0x90, 0xF0, // 6
            0xF0, 0x10, 0x20, 0x40, 0x40, // 7
            0xF0, 0x90, 0xF0, 0x90, 0xF0, // 8
            0xF0, 0x90, 0xF0, 0x10, 0xF0, // 9
            0xF0, 0x90, 0xF0, 0x90, 0x90, // A
            0xE0, 0x90, 0xE0, 0x90, 0xE0, // B
            0xF0, 0x80, 0x80, 0x80, 0xF0, // C
            0xE0, 0x90, 0x90, 0x90, 0xE0, // D
            0xF0, 0x80, 0xF0, 0x80, 0xF0, // E
            0xF0, 0x80, 0xF0, 0x80, 0x80  // F
        };

        public void Init()
        {

            Random rand = new Random();  // seed the random number generator


            this.programCounter = 0x200; // Program counter starts at 0x200
            this.opcode = 0;
            this.index = 0;
            this.stackPointer = 0;
            this.delayTimer = 0;
            this.soundTimer = 0;

            Array.Clear(memory, 0, memory.Length);
            Array.Clear(graphics, 0, graphics.Length);
            Array.Clear(registers, 0, registers.Length);
            Array.Clear(stack, 0, stack.Length);
            Array.Clear(keys, 0, keys.Length);

        }

    }
}
