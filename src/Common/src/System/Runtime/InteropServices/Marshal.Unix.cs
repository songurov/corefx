// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.Runtime.InteropServices
{
    // Stand-in type for low-level assemblies to obtain Win32 errors
    internal static class Marshal
    {
        public static int GetLastWin32Error()
        {
            // issue: https://github.com/dotnet/corefx/issues/6778
            // Need to define and implement this for Linux
            return 0;
        }
        
        unsafe public static String PtrToStringAnsi(IntPtr ptr)
        {
            if (IntPtr.Zero == ptr) 
            {
                return null;
            }
            
            byte *pBytes = (byte *) ptr;
            int length = 0; 
            
            while (*pBytes != 0)
            {
                pBytes++;
                length++;
            }
            
            if (length == 0)
            {
                return String.Empty;
            }
            
            char [] chars = new char[length];
            pBytes = (byte *) ptr;
            
            for (int i=0; i<length; i++)
            {
                chars[i] = (char) pBytes[i]; 
            }
            
            return new string(chars);
        }
    }
}