// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#include "include/libcec/cec.h"
typedef const char* String;

#if defined(_WINDOWS)
#include "targetver.h"

#define WIN32_LEAN_AND_MEAN             // Exclude rarely-used stuff from Windows headers
// Windows Header Files
#include <windows.h>

#define _AnomalousExport __declspec(dllexport)
#endif



// reference additional headers your program requires here
