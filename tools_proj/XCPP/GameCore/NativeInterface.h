#ifndef __NativeInterface__
#define __NativeInterface__


#include "Common.h"
#include <iostream>
#include "Log.h"
#include "Vector3.h"
#include "XEntityMgr.h"

extern "C"
{
	typedef void(*CALLBACK)(unsigned char,const char*);
	typedef void(*EntyCallBack)(int entityid, const char* method, const char* arg);
	typedef void(*CompCallBack)(int entityid, const char* compnent, const char* arg);
	extern CALLBACK callback;
	extern EntyCallBack eCallback;
	extern CompCallBack cCallback;

	ENGINE_INTERFACE_EXPORT void iInitCallbackCommand(CALLBACK cb);
	ENGINE_INTERFACE_EXPORT void iInitEntityCall(EntyCallBack cb);
	ENGINE_INTERFACE_EXPORT void iInitCompnentCall(CompCallBack cb);
	ENGINE_INTERFACE_EXPORT int iAdd(int, int);
	ENGINE_INTERFACE_EXPORT int iSub(int*, int*);
	ENGINE_INTERFACE_EXPORT void iInitial(const char*,const char*);
	ENGINE_INTERFACE_EXPORT void iJson(const char*);
	ENGINE_INTERFACE_EXPORT void iPatch(const char*,const char*,const char*);
	ENGINE_INTERFACE_EXPORT void iVector();
};


#endif