﻿using System.Runtime.InteropServices;

namespace SdlSharp.Graphics
{
    /// <summary>
    /// Information about a renderer.
    /// </summary>
    public unsafe struct RendererInfo
    {
        /// <summary>
        /// The name of the renderer.
        /// </summary>
        [field: MarshalAs(UnmanagedType.LPStr)]
        public string Name { get; }

        /// <summary>
        /// The flags of the renderer.
        /// </summary>
        public RendererFlags Flags { get; }

        private readonly uint _textureFormatCount;
        private fixed uint _formats[16];

        /// <summary>
        /// The texture formats supported.
        /// </summary>
        public EnumeratedPixelFormat[] TextureFormats
        {
            get
            {
                var formats = new EnumeratedPixelFormat[(int)_textureFormatCount];
                for (var i = 0; i < (int)_textureFormatCount; i++)
                {
                    formats[i] = new EnumeratedPixelFormat(_formats[i]);
                }
                return formats;
            }
        }

        private readonly int _maxTextureWidth;
        private readonly int _maxTextureHeight;

        /// <summary>
        /// The maximum texture size.
        /// </summary>
        public Size MaxTextureSize => (_maxTextureWidth, _maxTextureHeight);
    }
}
