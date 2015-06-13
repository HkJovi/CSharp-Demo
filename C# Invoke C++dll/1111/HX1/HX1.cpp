// HX1.cpp : Defines the entry point for the DLL application.
//

#include "stdafx.h"
#include "HX1.h"

BOOL APIENTRY DllMain( HANDLE hModule, 
                       DWORD  ul_reason_for_call, 
                       LPVOID lpReserved
					 )
{
    switch (ul_reason_for_call)
	{
		case DLL_PROCESS_ATTACH:
		case DLL_THREAD_ATTACH:
		case DLL_THREAD_DETACH:
		case DLL_PROCESS_DETACH:
			break;
    }
    return TRUE;
}


extern "C"  _declspec(dllexport) int fun1(int x,int y)
{
   if (x<y)
   {
	   return y;
   }
   else
	   return x;
}

extern "C"  _declspec(dllexport) char * fun2()
{
   char * s="abcde";
   return s;
}