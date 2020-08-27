// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Threading;

namespace Microsoft.AspNetCore.Components.Forms
{
    /// <summary>
    /// Represents the data of a file selected from an <see cref="InputFile"/> component.
    /// <para>
    /// Note: Metadata is provided by the client and is untrusted.
    /// </para>
    /// </summary>
    public interface IBrowserFile
    {
        /// <summary>
        /// Gets the name of the file as specified by the browser.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the last modified date as specified by the browser.
        /// </summary>
        DateTimeOffset LastModified { get; }

        /// <summary>
        /// Gets the size of the file in bytes as specified by the browser.
        /// </summary>
        long Size { get; }

        /// <summary>
        /// Gets the MIME type of the file as specified by the browser.
        /// </summary>
        string ContentType { get; }

        /// <summary>
        /// Opens the stream for reading the uploaded file.
        /// </summary>
        /// <param name="maxAllowedSize">
        /// The maximum size that can be read from the Stream. Defaults to 500kb.
        /// <para>
        /// Calling <see cref="OpenReadStream(long, CancellationToken)"/>
        /// will throw if the uploaded file size, as specified by <see cref="Size"/> is larger than
        /// <paramref name="maxAllowedSize"/>. By default, uploading a file larger than 500kb will result in an exception.
        /// </para>
        /// <para>
        /// When specified, it is important to choose a value based on the largest size the calling code is expected to handle.
        /// Specifying an arbitrary large value may by a vector for resource exhaustion attacks in particular in Blazor Server.
        /// </para>
        /// </param>
        /// <param name="cancellationToken">A cancellation token to signal the cancellation of streaming file data.</param>
        /// <exception cref="IOException">Thrown if the Stream</exception>
        Stream OpenReadStream(long maxAllowedSize = 500 * 1024, CancellationToken cancellationToken = default);
    }
}
