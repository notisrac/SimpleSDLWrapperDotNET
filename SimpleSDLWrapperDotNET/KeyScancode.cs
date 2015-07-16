﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SimpleSDLWrapperDotNET
{
    /// <summary>
    /// An enumeration of the SDL keyboard scancode representation.
    /// Thanks to the SharpDL project
    /// </summary>
    public enum KeyScancode
    {
        Unknown = SDL.SDL_Scancode.SDL_SCANCODE_UNKNOWN,
        A = SDL.SDL_Scancode.SDL_SCANCODE_A,
        B = SDL.SDL_Scancode.SDL_SCANCODE_B,
        C = SDL.SDL_Scancode.SDL_SCANCODE_C,
        D = SDL.SDL_Scancode.SDL_SCANCODE_D,
        E = SDL.SDL_Scancode.SDL_SCANCODE_E,
        F = SDL.SDL_Scancode.SDL_SCANCODE_F,
        G = SDL.SDL_Scancode.SDL_SCANCODE_G,
        H = SDL.SDL_Scancode.SDL_SCANCODE_H,
        I = SDL.SDL_Scancode.SDL_SCANCODE_I,
        J = SDL.SDL_Scancode.SDL_SCANCODE_J,
        K = SDL.SDL_Scancode.SDL_SCANCODE_K,
        L = SDL.SDL_Scancode.SDL_SCANCODE_L,
        M = SDL.SDL_Scancode.SDL_SCANCODE_M,
        N = SDL.SDL_Scancode.SDL_SCANCODE_N,
        O = SDL.SDL_Scancode.SDL_SCANCODE_O,
        P = SDL.SDL_Scancode.SDL_SCANCODE_P,
        Q = SDL.SDL_Scancode.SDL_SCANCODE_Q,
        R = SDL.SDL_Scancode.SDL_SCANCODE_R,
        S = SDL.SDL_Scancode.SDL_SCANCODE_S,
        T = SDL.SDL_Scancode.SDL_SCANCODE_T,
        U = SDL.SDL_Scancode.SDL_SCANCODE_U,
        V = SDL.SDL_Scancode.SDL_SCANCODE_V,
        W = SDL.SDL_Scancode.SDL_SCANCODE_W,
        X = SDL.SDL_Scancode.SDL_SCANCODE_X,
        Y = SDL.SDL_Scancode.SDL_SCANCODE_Y,
        Z = SDL.SDL_Scancode.SDL_SCANCODE_Z,
        D1 = SDL.SDL_Scancode.SDL_SCANCODE_1,
        D2 = SDL.SDL_Scancode.SDL_SCANCODE_2,
        D3 = SDL.SDL_Scancode.SDL_SCANCODE_3,
        D4 = SDL.SDL_Scancode.SDL_SCANCODE_4,
        D5 = SDL.SDL_Scancode.SDL_SCANCODE_5,
        D6 = SDL.SDL_Scancode.SDL_SCANCODE_6,
        D7 = SDL.SDL_Scancode.SDL_SCANCODE_7,
        D8 = SDL.SDL_Scancode.SDL_SCANCODE_8,
        D9 = SDL.SDL_Scancode.SDL_SCANCODE_9,
        D0 = SDL.SDL_Scancode.SDL_SCANCODE_0,
        Return = SDL.SDL_Scancode.SDL_SCANCODE_RETURN,
        Escape = SDL.SDL_Scancode.SDL_SCANCODE_ESCAPE,
        Backspace = SDL.SDL_Scancode.SDL_SCANCODE_BACKSPACE,
        Tab = SDL.SDL_Scancode.SDL_SCANCODE_TAB,
        Space = SDL.SDL_Scancode.SDL_SCANCODE_SPACE,
        Minus = SDL.SDL_Scancode.SDL_SCANCODE_MINUS,
        Equals = SDL.SDL_Scancode.SDL_SCANCODE_EQUALS,
        LeftBracket = SDL.SDL_Scancode.SDL_SCANCODE_LEFTBRACKET,
        RightBracket = SDL.SDL_Scancode.SDL_SCANCODE_RIGHTBRACKET,
        BackSlash = SDL.SDL_Scancode.SDL_SCANCODE_BACKSLASH,
        NonUSHash = SDL.SDL_Scancode.SDL_SCANCODE_NONUSHASH,
        Semicolon = SDL.SDL_Scancode.SDL_SCANCODE_SEMICOLON,
        Apostrophe = SDL.SDL_Scancode.SDL_SCANCODE_APOSTROPHE,
        Grave = SDL.SDL_Scancode.SDL_SCANCODE_GRAVE,
        Comma = SDL.SDL_Scancode.SDL_SCANCODE_COMMA,
        Period = SDL.SDL_Scancode.SDL_SCANCODE_PERIOD,
        Slash = SDL.SDL_Scancode.SDL_SCANCODE_SLASH,
        CapsLock = SDL.SDL_Scancode.SDL_SCANCODE_CAPSLOCK,
        F1 = SDL.SDL_Scancode.SDL_SCANCODE_F1,
        F2 = SDL.SDL_Scancode.SDL_SCANCODE_F2,
        F3 = SDL.SDL_Scancode.SDL_SCANCODE_F3,
        F4 = SDL.SDL_Scancode.SDL_SCANCODE_F4,
        F5 = SDL.SDL_Scancode.SDL_SCANCODE_F5,
        F6 = SDL.SDL_Scancode.SDL_SCANCODE_F6,
        F7 = SDL.SDL_Scancode.SDL_SCANCODE_F7,
        F8 = SDL.SDL_Scancode.SDL_SCANCODE_F8,
        F9 = SDL.SDL_Scancode.SDL_SCANCODE_F9,
        F10 = SDL.SDL_Scancode.SDL_SCANCODE_F10,
        F11 = SDL.SDL_Scancode.SDL_SCANCODE_F11,
        F12 = SDL.SDL_Scancode.SDL_SCANCODE_F12,
        PrintScreen = SDL.SDL_Scancode.SDL_SCANCODE_PRINTSCREEN,
        ScrollLock = SDL.SDL_Scancode.SDL_SCANCODE_SCROLLLOCK,
        Pause = SDL.SDL_Scancode.SDL_SCANCODE_PAUSE,
        Insert = SDL.SDL_Scancode.SDL_SCANCODE_INSERT,
        Home = SDL.SDL_Scancode.SDL_SCANCODE_HOME,
        PageUp = SDL.SDL_Scancode.SDL_SCANCODE_PAGEUP,
        Delete = SDL.SDL_Scancode.SDL_SCANCODE_DELETE,
        End = SDL.SDL_Scancode.SDL_SCANCODE_END,
        PageDown = SDL.SDL_Scancode.SDL_SCANCODE_PAGEDOWN,
        ArrowRight = SDL.SDL_Scancode.SDL_SCANCODE_RIGHT,
        ArrowLeft = SDL.SDL_Scancode.SDL_SCANCODE_LEFT,
        ArrowDown = SDL.SDL_Scancode.SDL_SCANCODE_DOWN,
        ArrowUp = SDL.SDL_Scancode.SDL_SCANCODE_UP,
        NumLockClear = SDL.SDL_Scancode.SDL_SCANCODE_NUMLOCKCLEAR,
        NumPadDivide = SDL.SDL_Scancode.SDL_SCANCODE_KP_DIVIDE,
        NumPadMultiply = SDL.SDL_Scancode.SDL_SCANCODE_KP_MULTIPLY,
        NumPadMinus = SDL.SDL_Scancode.SDL_SCANCODE_KP_MINUS,
        NumPadPlus = SDL.SDL_Scancode.SDL_SCANCODE_KP_PLUS,
        NumPadEnter = SDL.SDL_Scancode.SDL_SCANCODE_KP_ENTER,
        NumPad1 = SDL.SDL_Scancode.SDL_SCANCODE_KP_1,
        NumPad2 = SDL.SDL_Scancode.SDL_SCANCODE_KP_2,
        NumPad3 = SDL.SDL_Scancode.SDL_SCANCODE_KP_3,
        NumPad4 = SDL.SDL_Scancode.SDL_SCANCODE_KP_4,
        NumPad5 = SDL.SDL_Scancode.SDL_SCANCODE_KP_5,
        NumPad6 = SDL.SDL_Scancode.SDL_SCANCODE_KP_6,
        NumPad7 = SDL.SDL_Scancode.SDL_SCANCODE_KP_7,
        NumPad8 = SDL.SDL_Scancode.SDL_SCANCODE_KP_8,
        NumPad9 = SDL.SDL_Scancode.SDL_SCANCODE_KP_9,
        NumPad0 = SDL.SDL_Scancode.SDL_SCANCODE_KP_0,
        NumPadPeriod = SDL.SDL_Scancode.SDL_SCANCODE_KP_PERIOD,
        NonUSBackSlash = SDL.SDL_Scancode.SDL_SCANCODE_NONUSBACKSLASH,
        Application = SDL.SDL_Scancode.SDL_SCANCODE_APPLICATION,
        Power = SDL.SDL_Scancode.SDL_SCANCODE_POWER,
        NumPadEquals = SDL.SDL_Scancode.SDL_SCANCODE_KP_EQUALS,
        F13 = SDL.SDL_Scancode.SDL_SCANCODE_F13,
        F14 = SDL.SDL_Scancode.SDL_SCANCODE_F14,
        F15 = SDL.SDL_Scancode.SDL_SCANCODE_F15,
        F16 = SDL.SDL_Scancode.SDL_SCANCODE_F16,
        F17 = SDL.SDL_Scancode.SDL_SCANCODE_F17,
        F18 = SDL.SDL_Scancode.SDL_SCANCODE_F18,
        F19 = SDL.SDL_Scancode.SDL_SCANCODE_F19,
        F20 = SDL.SDL_Scancode.SDL_SCANCODE_F20,
        F21 = SDL.SDL_Scancode.SDL_SCANCODE_F21,
        F22 = SDL.SDL_Scancode.SDL_SCANCODE_F22,
        F23 = SDL.SDL_Scancode.SDL_SCANCODE_F23,
        F24 = SDL.SDL_Scancode.SDL_SCANCODE_F24,
        Execute = SDL.SDL_Scancode.SDL_SCANCODE_EXECUTE,
        Help = SDL.SDL_Scancode.SDL_SCANCODE_HELP,
        Menu = SDL.SDL_Scancode.SDL_SCANCODE_MENU,
        Select = SDL.SDL_Scancode.SDL_SCANCODE_SELECT,
        Stop = SDL.SDL_Scancode.SDL_SCANCODE_STOP,
        Again = SDL.SDL_Scancode.SDL_SCANCODE_AGAIN,
        Undo = SDL.SDL_Scancode.SDL_SCANCODE_UNDO,
        Cut = SDL.SDL_Scancode.SDL_SCANCODE_CUT,
        Copy = SDL.SDL_Scancode.SDL_SCANCODE_COPY,
        Paste = SDL.SDL_Scancode.SDL_SCANCODE_PASTE,
        Find = SDL.SDL_Scancode.SDL_SCANCODE_FIND,
        Mute = SDL.SDL_Scancode.SDL_SCANCODE_MUTE,
        VolumeUp = SDL.SDL_Scancode.SDL_SCANCODE_VOLUMEUP,
        VolumeDown = SDL.SDL_Scancode.SDL_SCANCODE_VOLUMEDOWN,
        NumPadComma = SDL.SDL_Scancode.SDL_SCANCODE_KP_COMMA,
        AltErase = SDL.SDL_Scancode.SDL_SCANCODE_ALTERASE,
        Cancel = SDL.SDL_Scancode.SDL_SCANCODE_CANCEL,
        Clear = SDL.SDL_Scancode.SDL_SCANCODE_CLEAR,
        Prior = SDL.SDL_Scancode.SDL_SCANCODE_PRIOR,
        Return2 = SDL.SDL_Scancode.SDL_SCANCODE_RETURN2,
        Separator = SDL.SDL_Scancode.SDL_SCANCODE_SEPARATOR,
        LeftControl = SDL.SDL_Scancode.SDL_SCANCODE_LCTRL,
        LeftShift = SDL.SDL_Scancode.SDL_SCANCODE_LSHIFT,
        LeftAlt = SDL.SDL_Scancode.SDL_SCANCODE_LALT,
        RightControl = SDL.SDL_Scancode.SDL_SCANCODE_RCTRL,
        RightAlt = SDL.SDL_Scancode.SDL_SCANCODE_RALT,
        AudioNext = SDL.SDL_Scancode.SDL_SCANCODE_AUDIONEXT,
        AudioPrev = SDL.SDL_Scancode.SDL_SCANCODE_AUDIOPREV,
        AudioStop = SDL.SDL_Scancode.SDL_SCANCODE_AUDIOSTOP,
        AudioPlay = SDL.SDL_Scancode.SDL_SCANCODE_AUDIOPLAY,
        AudioMute = SDL.SDL_Scancode.SDL_SCANCODE_AUDIOMUTE,
        Browser = SDL.SDL_Scancode.SDL_SCANCODE_WWW,
        Mail = SDL.SDL_Scancode.SDL_SCANCODE_MAIL,
        Calculator = SDL.SDL_Scancode.SDL_SCANCODE_CALCULATOR,
        Computer = SDL.SDL_Scancode.SDL_SCANCODE_COMPUTER,
        BrightnessDown = SDL.SDL_Scancode.SDL_SCANCODE_BRIGHTNESSDOWN,
        BrightnessUp = SDL.SDL_Scancode.SDL_SCANCODE_BRIGHTNESSUP,
        Eject = SDL.SDL_Scancode.SDL_SCANCODE_EJECT,
        Sleep = SDL.SDL_Scancode.SDL_SCANCODE_SLEEP,
        LeftWindowsKey = SDL.SDL_Scancode.SDL_SCANCODE_LGUI,
        RightWindowsKey = SDL.SDL_Scancode.SDL_SCANCODE_RGUI
    }
}