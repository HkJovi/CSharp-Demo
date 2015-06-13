
// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the HX1_EXPORTS
// symbol defined on the command line. this symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// HX1_API functions as being imported from a DLL, wheras this DLL sees symbols
// defined with this macro as being exported.
#ifdef HX1_EXPORTS
#define HX1_API __declspec(dllexport)
#else
#define HX1_API __declspec(dllimport)
#endif

// This class is exported from the HX1.dll
class HX1_API CHX1 {
public:
	CHX1(void);
	// TODO: add your methods here.
};

extern HX1_API int nHX1;

HX1_API int fnHX1(void);

