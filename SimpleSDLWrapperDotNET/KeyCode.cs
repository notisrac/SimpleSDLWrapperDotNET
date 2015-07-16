﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDL2;

namespace SimpleSDLWrapperDotNET
{
    /// <summary>
    /// The SDL virtual key representation. 
    /// Thanks to the SharpDL project
    /// </summary>
    public enum KeyCode
    {
        Unknown = SDL.SDL_Keycode.SDLK_UNKNOWN,
        A = SDL.SDL_Keycode.SDLK_a,
        B = SDL.SDL_Keycode.SDLK_b,
        C = SDL.SDL_Keycode.SDLK_c,
        D = SDL.SDL_Keycode.SDLK_d,
        E = SDL.SDL_Keycode.SDLK_e,
        F = SDL.SDL_Keycode.SDLK_f,
        G = SDL.SDL_Keycode.SDLK_g,
        H = SDL.SDL_Keycode.SDLK_h,
        I = SDL.SDL_Keycode.SDLK_i,
        J = SDL.SDL_Keycode.SDLK_j,
        K = SDL.SDL_Keycode.SDLK_k,
        L = SDL.SDL_Keycode.SDLK_l,
        M = SDL.SDL_Keycode.SDLK_m,
        N = SDL.SDL_Keycode.SDLK_n,
        O = SDL.SDL_Keycode.SDLK_o,
        P = SDL.SDL_Keycode.SDLK_p,
        Q = SDL.SDL_Keycode.SDLK_q,
        R = SDL.SDL_Keycode.SDLK_r,
        S = SDL.SDL_Keycode.SDLK_s,
        T = SDL.SDL_Keycode.SDLK_t,
        U = SDL.SDL_Keycode.SDLK_u,
        V = SDL.SDL_Keycode.SDLK_v,
        W = SDL.SDL_Keycode.SDLK_w,
        X = SDL.SDL_Keycode.SDLK_x,
        Y = SDL.SDL_Keycode.SDLK_y,
        Z = SDL.SDL_Keycode.SDLK_z,
        D1 = SDL.SDL_Keycode.SDLK_1,
        D2 = SDL.SDL_Keycode.SDLK_2,
        D3 = SDL.SDL_Keycode.SDLK_3,
        D4 = SDL.SDL_Keycode.SDLK_4,
        D5 = SDL.SDL_Keycode.SDLK_5,
        D6 = SDL.SDL_Keycode.SDLK_6,
        D7 = SDL.SDL_Keycode.SDLK_7,
        D8 = SDL.SDL_Keycode.SDLK_8,
        D9 = SDL.SDL_Keycode.SDLK_9,
        D0 = SDL.SDL_Keycode.SDLK_0,
        Exclaim = SDL.SDL_Keycode.SDLK_EXCLAIM,
        Dollar = SDL.SDL_Keycode.SDLK_DOLLAR,
        Percent = SDL.SDL_Keycode.SDLK_PERCENT,
        Ampersand = SDL.SDL_Keycode.SDLK_AMPERSAND,
        Quote = SDL.SDL_Keycode.SDLK_QUOTE,
        LeftParenthesis = SDL.SDL_Keycode.SDLK_LEFTPAREN,
        RightParenthesis = SDL.SDL_Keycode.SDLK_RIGHTPAREN,
        Asterisk = SDL.SDL_Keycode.SDLK_ASTERISK,
        Colon = SDL.SDL_Keycode.SDLK_COLON,
        LessThan = SDL.SDL_Keycode.SDLK_LESS,
        GreaterThan = SDL.SDL_Keycode.SDLK_GREATER,
        QuestionMark = SDL.SDL_Keycode.SDLK_QUESTION,
        AtSymbol = SDL.SDL_Keycode.SDLK_AT,
        LeftBracket = SDL.SDL_Keycode.SDLK_LEFTBRACKET,
        RightBracket = SDL.SDL_Keycode.SDLK_RIGHTBRACKET,
        Caret = SDL.SDL_Keycode.SDLK_CARET,
        Underscore = SDL.SDL_Keycode.SDLK_UNDERSCORE,
        Return = SDL.SDL_Keycode.SDLK_RETURN,
        Escape = SDL.SDL_Keycode.SDLK_ESCAPE,
        Backspace = SDL.SDL_Keycode.SDLK_BACKSPACE,
        Tab = SDL.SDL_Keycode.SDLK_TAB,
        Space = SDL.SDL_Keycode.SDLK_SPACE,
        Minus = SDL.SDL_Keycode.SDLK_MINUS,
        Equals = SDL.SDL_Keycode.SDLK_EQUALS,
        BackSlash = SDL.SDL_Keycode.SDLK_BACKSLASH,
        Hash = SDL.SDL_Keycode.SDLK_HASH,
        Semicolon = SDL.SDL_Keycode.SDLK_SEMICOLON,
        Comma = SDL.SDL_Keycode.SDLK_COMMA,
        Period = SDL.SDL_Keycode.SDLK_PERIOD,
        Slash = SDL.SDL_Keycode.SDLK_SLASH,
        CapsLock = SDL.SDL_Keycode.SDLK_CAPSLOCK,
        F1 = SDL.SDL_Keycode.SDLK_F1,
        F2 = SDL.SDL_Keycode.SDLK_F2,
        F3 = SDL.SDL_Keycode.SDLK_F3,
        F4 = SDL.SDL_Keycode.SDLK_F4,
        F5 = SDL.SDL_Keycode.SDLK_F5,
        F6 = SDL.SDL_Keycode.SDLK_F6,
        F7 = SDL.SDL_Keycode.SDLK_F7,
        F8 = SDL.SDL_Keycode.SDLK_F8,
        F9 = SDL.SDL_Keycode.SDLK_F9,
        F10 = SDL.SDL_Keycode.SDLK_F10,
        F11 = SDL.SDL_Keycode.SDLK_F11,
        F12 = SDL.SDL_Keycode.SDLK_F12,
        PrintScreen = SDL.SDL_Keycode.SDLK_PRINTSCREEN,
        ScrollLock = SDL.SDL_Keycode.SDLK_SCROLLLOCK,
        Pause = SDL.SDL_Keycode.SDLK_PAUSE,
        Insert = SDL.SDL_Keycode.SDLK_INSERT,
        Home = SDL.SDL_Keycode.SDLK_HOME,
        PageUp = SDL.SDL_Keycode.SDLK_PAGEUP,
        Delete = SDL.SDL_Keycode.SDLK_DELETE,
        End = SDL.SDL_Keycode.SDLK_END,
        PageDown = SDL.SDL_Keycode.SDLK_PAGEDOWN,
        ArrowRight = SDL.SDL_Keycode.SDLK_RIGHT,
        ArrowLeft = SDL.SDL_Keycode.SDLK_LEFT,
        ArrowDown = SDL.SDL_Keycode.SDLK_DOWN,
        ArrowUp = SDL.SDL_Keycode.SDLK_UP,
        NumLockClear = SDL.SDL_Keycode.SDLK_NUMLOCKCLEAR,
        NumPadDivide = SDL.SDL_Keycode.SDLK_KP_DIVIDE,
        NumPadMultiply = SDL.SDL_Keycode.SDLK_KP_MULTIPLY,
        NumPadMinus = SDL.SDL_Keycode.SDLK_KP_MINUS,
        NumPadPlus = SDL.SDL_Keycode.SDLK_KP_PLUS,
        NumPadEnter = SDL.SDL_Keycode.SDLK_KP_ENTER,
        NumPad1 = SDL.SDL_Keycode.SDLK_KP_1,
        NumPad2 = SDL.SDL_Keycode.SDLK_KP_2,
        NumPad3 = SDL.SDL_Keycode.SDLK_KP_3,
        NumPad4 = SDL.SDL_Keycode.SDLK_KP_4,
        NumPad5 = SDL.SDL_Keycode.SDLK_KP_5,
        NumPad6 = SDL.SDL_Keycode.SDLK_KP_6,
        NumPad7 = SDL.SDL_Keycode.SDLK_KP_7,
        NumPad8 = SDL.SDL_Keycode.SDLK_KP_8,
        NumPad9 = SDL.SDL_Keycode.SDLK_KP_9,
        NumPad0 = SDL.SDL_Keycode.SDLK_KP_0,
        NumPadPeriod = SDL.SDL_Keycode.SDLK_KP_PERIOD,
        Application = SDL.SDL_Keycode.SDLK_APPLICATION,
        Power = SDL.SDL_Keycode.SDLK_POWER,
        NumPadEquals = SDL.SDL_Keycode.SDLK_KP_EQUALS,
        F13 = SDL.SDL_Keycode.SDLK_F13,
        F14 = SDL.SDL_Keycode.SDLK_F14,
        F15 = SDL.SDL_Keycode.SDLK_F15,
        F16 = SDL.SDL_Keycode.SDLK_F16,
        F17 = SDL.SDL_Keycode.SDLK_F17,
        F18 = SDL.SDL_Keycode.SDLK_F18,
        F19 = SDL.SDL_Keycode.SDLK_F19,
        F20 = SDL.SDL_Keycode.SDLK_F20,
        F21 = SDL.SDL_Keycode.SDLK_F21,
        F22 = SDL.SDL_Keycode.SDLK_F22,
        F23 = SDL.SDL_Keycode.SDLK_F23,
        F24 = SDL.SDL_Keycode.SDLK_F24,
        Execute = SDL.SDL_Keycode.SDLK_EXECUTE,
        Help = SDL.SDL_Keycode.SDLK_HELP,
        Menu = SDL.SDL_Keycode.SDLK_MENU,
        Select = SDL.SDL_Keycode.SDLK_SELECT,
        Stop = SDL.SDL_Keycode.SDLK_STOP,
        Again = SDL.SDL_Keycode.SDLK_AGAIN,
        Undo = SDL.SDL_Keycode.SDLK_UNDO,
        Cut = SDL.SDL_Keycode.SDLK_CUT,
        Copy = SDL.SDL_Keycode.SDLK_COPY,
        Paste = SDL.SDL_Keycode.SDLK_PASTE,
        Find = SDL.SDL_Keycode.SDLK_FIND,
        Mute = SDL.SDL_Keycode.SDLK_MUTE,
        VolumeUp = SDL.SDL_Keycode.SDLK_VOLUMEUP,
        VolumeDown = SDL.SDL_Keycode.SDLK_VOLUMEDOWN,
        NumPadComma = SDL.SDL_Keycode.SDLK_KP_COMMA,
        AltErase = SDL.SDL_Keycode.SDLK_ALTERASE,
        Cancel = SDL.SDL_Keycode.SDLK_CANCEL,
        Clear = SDL.SDL_Keycode.SDLK_CLEAR,
        Prior = SDL.SDL_Keycode.SDLK_PRIOR,
        Return2 = SDL.SDL_Keycode.SDLK_RETURN2,
        Separator = SDL.SDL_Keycode.SDLK_SEPARATOR,
        LeftControl = SDL.SDL_Keycode.SDLK_LCTRL,
        LeftShift = SDL.SDL_Keycode.SDLK_LSHIFT,
        LeftAlt = SDL.SDL_Keycode.SDLK_LALT,
        RightControl = SDL.SDL_Keycode.SDLK_RCTRL,
        RightAlt = SDL.SDL_Keycode.SDLK_RALT,
        AudioNext = SDL.SDL_Keycode.SDLK_AUDIONEXT,
        AudioPrev = SDL.SDL_Keycode.SDLK_AUDIOPREV,
        AudioStop = SDL.SDL_Keycode.SDLK_AUDIOSTOP,
        AudioPlay = SDL.SDL_Keycode.SDLK_AUDIOPLAY,
        AudioMute = SDL.SDL_Keycode.SDLK_AUDIOMUTE,
        Browser = SDL.SDL_Keycode.SDLK_WWW,
        Mail = SDL.SDL_Keycode.SDLK_MAIL,
        Calculator = SDL.SDL_Keycode.SDLK_CALCULATOR,
        Computer = SDL.SDL_Keycode.SDLK_COMPUTER,
        BrightnessDown = SDL.SDL_Keycode.SDLK_BRIGHTNESSDOWN,
        BrightnessUp = SDL.SDL_Keycode.SDLK_BRIGHTNESSUP,
        Eject = SDL.SDL_Keycode.SDLK_EJECT,
        Sleep = SDL.SDL_Keycode.SDLK_SLEEP,
        LeftWindowsKey = SDL.SDL_Keycode.SDLK_LGUI,
        RightWindowsKey = SDL.SDL_Keycode.SDLK_RGUI
    }
}