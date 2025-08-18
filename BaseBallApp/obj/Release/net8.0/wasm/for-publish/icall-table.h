#define ICALL_TABLE_corlib 1

static int corlib_icall_indexes [] = {
224,
236,
237,
238,
239,
240,
241,
242,
243,
244,
247,
248,
249,
419,
420,
421,
450,
451,
452,
472,
473,
474,
475,
592,
593,
594,
597,
635,
636,
638,
640,
642,
644,
649,
657,
658,
659,
660,
661,
662,
663,
664,
665,
666,
667,
668,
669,
670,
671,
672,
673,
675,
676,
677,
678,
679,
680,
681,
778,
779,
780,
781,
782,
783,
784,
785,
786,
787,
788,
789,
790,
791,
792,
793,
794,
796,
797,
798,
799,
800,
801,
802,
869,
870,
938,
944,
947,
949,
954,
955,
957,
958,
962,
964,
965,
967,
969,
970,
973,
974,
975,
978,
980,
983,
985,
987,
996,
1064,
1066,
1068,
1078,
1079,
1080,
1081,
1083,
1090,
1091,
1092,
1093,
1094,
1102,
1103,
1104,
1108,
1109,
1111,
1115,
1116,
1117,
1396,
1588,
1589,
9423,
9424,
9426,
9427,
9428,
9429,
9430,
9432,
9434,
9436,
9437,
9438,
9449,
9451,
9456,
9458,
9460,
9462,
9511,
9517,
9518,
9520,
9521,
9522,
9523,
9524,
9526,
9528,
10592,
10596,
10598,
10599,
10600,
10601,
10859,
10860,
10861,
10862,
10882,
10883,
10884,
10886,
10931,
10993,
10995,
10997,
11007,
11008,
11009,
11010,
11011,
11485,
11486,
11490,
11491,
11524,
11559,
11566,
11573,
11584,
11588,
11611,
11693,
11695,
11705,
11707,
11708,
11709,
11716,
11731,
11751,
11752,
11760,
11762,
11769,
11770,
11773,
11775,
11780,
11786,
11787,
11794,
11796,
11808,
11811,
11812,
11813,
11824,
11833,
11839,
11840,
11841,
11843,
11844,
11861,
11863,
11877,
11897,
11898,
11925,
11955,
11956,
12563,
12656,
12657,
12867,
12868,
12876,
12877,
12878,
12883,
12961,
13434,
13435,
13842,
13847,
13857,
15224,
15245,
15247,
15249,
};
void ves_icall_System_Array_InternalCreate (int,int,int,int,int);
int ves_icall_System_Array_GetCorElementTypeOfElementTypeInternal (int);
int ves_icall_System_Array_IsValueOfElementTypeInternal (int,int);
int ves_icall_System_Array_CanChangePrimitive (int,int,int);
int ves_icall_System_Array_FastCopy (int,int,int,int,int);
int ves_icall_System_Array_GetLengthInternal_raw (int,int,int);
int ves_icall_System_Array_GetLowerBoundInternal_raw (int,int,int);
void ves_icall_System_Array_GetGenericValue_icall (int,int,int);
void ves_icall_System_Array_GetValueImpl_raw (int,int,int,int);
void ves_icall_System_Array_SetGenericValue_icall (int,int,int);
void ves_icall_System_Array_SetValueImpl_raw (int,int,int,int);
void ves_icall_System_Array_InitializeInternal_raw (int,int);
void ves_icall_System_Array_SetValueRelaxedImpl_raw (int,int,int,int);
void ves_icall_System_Runtime_RuntimeImports_ZeroMemory (int,int);
void ves_icall_System_Runtime_RuntimeImports_Memmove (int,int,int);
void ves_icall_System_Buffer_BulkMoveWithWriteBarrier (int,int,int,int);
int ves_icall_System_Delegate_AllocDelegateLike_internal_raw (int,int);
int ves_icall_System_Delegate_CreateDelegate_internal_raw (int,int,int,int,int);
int ves_icall_System_Delegate_GetVirtualMethod_internal_raw (int,int);
void ves_icall_System_Enum_GetEnumValuesAndNames_raw (int,int,int,int);
void ves_icall_System_Enum_InternalBoxEnum_raw (int,int,int64_t,int);
int ves_icall_System_Enum_InternalGetCorElementType (int);
void ves_icall_System_Enum_InternalGetUnderlyingType_raw (int,int,int);
int ves_icall_System_Environment_get_ProcessorCount ();
int ves_icall_System_Environment_get_TickCount ();
int64_t ves_icall_System_Environment_get_TickCount64 ();
void ves_icall_System_Environment_FailFast_raw (int,int,int,int);
void ves_icall_System_GC_register_ephemeron_array_raw (int,int);
int ves_icall_System_GC_get_ephemeron_tombstone_raw (int);
void ves_icall_System_GC_SuppressFinalize_raw (int,int);
void ves_icall_System_GC_ReRegisterForFinalize_raw (int,int);
void ves_icall_System_GC_GetGCMemoryInfo (int,int,int,int,int,int);
int ves_icall_System_GC_AllocPinnedArray_raw (int,int,int);
int ves_icall_System_Object_MemberwiseClone_raw (int,int);
double ves_icall_System_Math_Acos (double);
double ves_icall_System_Math_Acosh (double);
double ves_icall_System_Math_Asin (double);
double ves_icall_System_Math_Asinh (double);
double ves_icall_System_Math_Atan (double);
double ves_icall_System_Math_Atan2 (double,double);
double ves_icall_System_Math_Atanh (double);
double ves_icall_System_Math_Cbrt (double);
double ves_icall_System_Math_Ceiling (double);
double ves_icall_System_Math_Cos (double);
double ves_icall_System_Math_Cosh (double);
double ves_icall_System_Math_Exp (double);
double ves_icall_System_Math_Floor (double);
double ves_icall_System_Math_Log (double);
double ves_icall_System_Math_Log10 (double);
double ves_icall_System_Math_Pow (double,double);
double ves_icall_System_Math_Sin (double);
double ves_icall_System_Math_Sinh (double);
double ves_icall_System_Math_Sqrt (double);
double ves_icall_System_Math_Tan (double);
double ves_icall_System_Math_Tanh (double);
double ves_icall_System_Math_FusedMultiplyAdd (double,double,double);
double ves_icall_System_Math_Log2 (double);
double ves_icall_System_Math_ModF (double,int);
float ves_icall_System_MathF_Acos (float);
float ves_icall_System_MathF_Acosh (float);
float ves_icall_System_MathF_Asin (float);
float ves_icall_System_MathF_Asinh (float);
float ves_icall_System_MathF_Atan (float);
float ves_icall_System_MathF_Atan2 (float,float);
float ves_icall_System_MathF_Atanh (float);
float ves_icall_System_MathF_Cbrt (float);
float ves_icall_System_MathF_Ceiling (float);
float ves_icall_System_MathF_Cos (float);
float ves_icall_System_MathF_Cosh (float);
float ves_icall_System_MathF_Exp (float);
float ves_icall_System_MathF_Floor (float);
float ves_icall_System_MathF_Log (float);
float ves_icall_System_MathF_Log10 (float);
float ves_icall_System_MathF_Pow (float,float);
float ves_icall_System_MathF_Sin (float);
float ves_icall_System_MathF_Sinh (float);
float ves_icall_System_MathF_Sqrt (float);
float ves_icall_System_MathF_Tan (float);
float ves_icall_System_MathF_Tanh (float);
float ves_icall_System_MathF_FusedMultiplyAdd (float,float,float);
float ves_icall_System_MathF_Log2 (float);
float ves_icall_System_MathF_ModF (float,int);
void ves_icall_RuntimeMethodHandle_ReboxFromNullable_raw (int,int,int);
void ves_icall_RuntimeMethodHandle_ReboxToNullable_raw (int,int,int,int);
int ves_icall_RuntimeType_GetCorrespondingInflatedMethod_raw (int,int,int);
void ves_icall_RuntimeType_make_array_type_raw (int,int,int,int);
void ves_icall_RuntimeType_make_byref_type_raw (int,int,int);
void ves_icall_RuntimeType_make_pointer_type_raw (int,int,int);
void ves_icall_RuntimeType_MakeGenericType_raw (int,int,int,int);
int ves_icall_RuntimeType_GetMethodsByName_native_raw (int,int,int,int,int);
int ves_icall_RuntimeType_GetPropertiesByName_native_raw (int,int,int,int,int);
int ves_icall_RuntimeType_GetConstructors_native_raw (int,int,int);
void ves_icall_RuntimeType_GetInterfaceMapData_raw (int,int,int,int,int);
int ves_icall_System_RuntimeType_CreateInstanceInternal_raw (int,int);
void ves_icall_System_RuntimeType_AllocateValueType_raw (int,int,int,int);
void ves_icall_RuntimeType_GetDeclaringMethod_raw (int,int,int);
void ves_icall_System_RuntimeType_getFullName_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetGenericArgumentsInternal_raw (int,int,int,int);
int ves_icall_RuntimeType_GetGenericParameterPosition (int);
int ves_icall_RuntimeType_GetEvents_native_raw (int,int,int,int);
int ves_icall_RuntimeType_GetFields_native_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetInterfaces_raw (int,int,int);
int ves_icall_RuntimeType_GetNestedTypes_native_raw (int,int,int,int,int);
void ves_icall_RuntimeType_GetDeclaringType_raw (int,int,int);
void ves_icall_RuntimeType_GetName_raw (int,int,int);
void ves_icall_RuntimeType_GetNamespace_raw (int,int,int);
int ves_icall_RuntimeType_FunctionPointerReturnAndParameterTypes_raw (int,int);
int ves_icall_RuntimeTypeHandle_GetAttributes (int);
int ves_icall_RuntimeTypeHandle_GetMetadataToken_raw (int,int);
void ves_icall_RuntimeTypeHandle_GetGenericTypeDefinition_impl_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_GetCorElementType (int);
int ves_icall_RuntimeTypeHandle_HasInstantiation (int);
int ves_icall_RuntimeTypeHandle_IsComObject_raw (int,int);
int ves_icall_RuntimeTypeHandle_IsInstanceOfType_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_HasReferences_raw (int,int);
int ves_icall_RuntimeTypeHandle_GetArrayRank_raw (int,int);
void ves_icall_RuntimeTypeHandle_GetAssembly_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetElementType_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetModule_raw (int,int,int);
void ves_icall_RuntimeTypeHandle_GetBaseType_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_type_is_assignable_from_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_IsGenericTypeDefinition (int);
int ves_icall_RuntimeTypeHandle_GetGenericParameterInfo_raw (int,int);
int ves_icall_RuntimeTypeHandle_is_subclass_of_raw (int,int,int);
int ves_icall_RuntimeTypeHandle_IsByRefLike_raw (int,int);
void ves_icall_System_RuntimeTypeHandle_internal_from_name_raw (int,int,int,int,int,int);
int ves_icall_System_String_FastAllocateString_raw (int,int);
int ves_icall_System_String_InternalIsInterned_raw (int,int);
int ves_icall_System_String_InternalIntern_raw (int,int);
int ves_icall_System_Type_internal_from_handle_raw (int,int);
int ves_icall_System_ValueType_InternalGetHashCode_raw (int,int,int);
int ves_icall_System_ValueType_Equals_raw (int,int,int,int);
int ves_icall_System_Threading_Interlocked_CompareExchange_Int (int,int,int);
void ves_icall_System_Threading_Interlocked_CompareExchange_Object (int,int,int,int);
int ves_icall_System_Threading_Interlocked_Decrement_Int (int);
int ves_icall_System_Threading_Interlocked_Increment_Int (int);
int64_t ves_icall_System_Threading_Interlocked_Increment_Long (int);
int ves_icall_System_Threading_Interlocked_Exchange_Int (int,int);
void ves_icall_System_Threading_Interlocked_Exchange_Object (int,int,int);
int64_t ves_icall_System_Threading_Interlocked_CompareExchange_Long (int,int64_t,int64_t);
int64_t ves_icall_System_Threading_Interlocked_Exchange_Long (int,int64_t);
int64_t ves_icall_System_Threading_Interlocked_Read_Long (int);
int ves_icall_System_Threading_Interlocked_Add_Int (int,int);
int64_t ves_icall_System_Threading_Interlocked_Add_Long (int,int64_t);
void ves_icall_System_Threading_Monitor_Monitor_Enter_raw (int,int);
void mono_monitor_exit_icall_raw (int,int);
void ves_icall_System_Threading_Monitor_Monitor_pulse_raw (int,int);
void ves_icall_System_Threading_Monitor_Monitor_pulse_all_raw (int,int);
int ves_icall_System_Threading_Monitor_Monitor_wait_raw (int,int,int,int);
void ves_icall_System_Threading_Monitor_Monitor_try_enter_with_atomic_var_raw (int,int,int,int,int);
void ves_icall_System_Threading_Thread_StartInternal_raw (int,int,int);
void ves_icall_System_Threading_Thread_InitInternal_raw (int,int);
int ves_icall_System_Threading_Thread_GetCurrentThread ();
void ves_icall_System_Threading_InternalThread_Thread_free_internal_raw (int,int);
int ves_icall_System_Threading_Thread_GetState_raw (int,int);
void ves_icall_System_Threading_Thread_SetState_raw (int,int,int);
void ves_icall_System_Threading_Thread_ClrState_raw (int,int,int);
void ves_icall_System_Threading_Thread_SetName_icall_raw (int,int,int,int);
int ves_icall_System_Threading_Thread_YieldInternal ();
void ves_icall_System_Threading_Thread_SetPriority_raw (int,int,int);
void ves_icall_System_Runtime_Loader_AssemblyLoadContext_PrepareForAssemblyLoadContextRelease_raw (int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_GetLoadContextForAssembly_raw (int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFile_raw (int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalInitializeNativeALC_raw (int,int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFromStream_raw (int,int,int,int,int,int);
int ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalGetLoadedAssemblies_raw (int);
int ves_icall_System_GCHandle_InternalAlloc_raw (int,int,int);
void ves_icall_System_GCHandle_InternalFree_raw (int,int);
int ves_icall_System_GCHandle_InternalGet_raw (int,int);
void ves_icall_System_GCHandle_InternalSet_raw (int,int,int);
int ves_icall_System_Runtime_InteropServices_Marshal_GetLastPInvokeError ();
void ves_icall_System_Runtime_InteropServices_Marshal_SetLastPInvokeError (int);
void ves_icall_System_Runtime_InteropServices_Marshal_StructureToPtr_raw (int,int,int,int);
int ves_icall_System_Runtime_InteropServices_Marshal_SizeOfHelper_raw (int,int,int);
int ves_icall_System_Runtime_InteropServices_NativeLibrary_LoadByName_raw (int,int,int,int,int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalGetHashCode_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalTryGetHashCode_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetObjectValue_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetUninitializedObjectInternal_raw (int,int);
void ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InitializeArray_raw (int,int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetSpanDataFrom_raw (int,int,int,int);
void ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_RunClassConstructor_raw (int,int);
int ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_SufficientExecutionStack ();
int ves_icall_System_Reflection_Assembly_GetExecutingAssembly_raw (int,int);
int ves_icall_System_Reflection_Assembly_GetEntryAssembly_raw (int);
int ves_icall_System_Reflection_Assembly_InternalLoad_raw (int,int,int,int);
int ves_icall_System_Reflection_Assembly_InternalGetType_raw (int,int,int,int,int,int);
int ves_icall_System_Reflection_AssemblyName_GetNativeName (int);
int ves_icall_MonoCustomAttrs_GetCustomAttributesInternal_raw (int,int,int,int);
int ves_icall_MonoCustomAttrs_GetCustomAttributesDataInternal_raw (int,int);
int ves_icall_MonoCustomAttrs_IsDefinedInternal_raw (int,int,int);
int ves_icall_System_Reflection_FieldInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_System_Reflection_FieldInfo_get_marshal_info_raw (int,int);
int ves_icall_System_Reflection_LoaderAllocatorScout_Destroy (int);
void ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceNames_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetExportedTypes_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetInfo_raw (int,int,int,int);
int ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInternal_raw (int,int,int,int,int);
void ves_icall_System_Reflection_Assembly_GetManifestModuleInternal_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetModulesInternal_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeCustomAttributeData_ResolveArgumentsInternal_raw (int,int,int,int,int,int,int);
void ves_icall_RuntimeEventInfo_get_event_info_raw (int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_EventInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_RuntimeFieldInfo_ResolveType_raw (int,int);
int ves_icall_RuntimeFieldInfo_GetParentType_raw (int,int,int);
int ves_icall_RuntimeFieldInfo_GetFieldOffset_raw (int,int);
int ves_icall_RuntimeFieldInfo_GetValueInternal_raw (int,int,int);
void ves_icall_RuntimeFieldInfo_SetValueInternal_raw (int,int,int,int);
int ves_icall_RuntimeFieldInfo_GetRawConstantValue_raw (int,int);
int ves_icall_reflection_get_token_raw (int,int);
void ves_icall_get_method_info_raw (int,int,int);
int ves_icall_get_method_attributes (int);
int ves_icall_System_Reflection_MonoMethodInfo_get_parameter_info_raw (int,int,int);
int ves_icall_System_MonoMethodInfo_get_retval_marshal_raw (int,int);
int ves_icall_System_Reflection_RuntimeMethodInfo_GetMethodFromHandleInternalType_native_raw (int,int,int,int);
int ves_icall_RuntimeMethodInfo_get_name_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_base_method_raw (int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_InternalInvoke_raw (int,int,int,int,int);
void ves_icall_RuntimeMethodInfo_GetPInvoke_raw (int,int,int,int,int);
int ves_icall_RuntimeMethodInfo_MakeGenericMethod_impl_raw (int,int,int);
int ves_icall_RuntimeMethodInfo_GetGenericArguments_raw (int,int);
int ves_icall_RuntimeMethodInfo_GetGenericMethodDefinition_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_IsGenericMethodDefinition_raw (int,int);
int ves_icall_RuntimeMethodInfo_get_IsGenericMethod_raw (int,int);
void ves_icall_InvokeClassConstructor_raw (int,int);
int ves_icall_InternalInvoke_raw (int,int,int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_RuntimeModule_InternalGetTypes_raw (int,int);
int ves_icall_System_Reflection_RuntimeModule_ResolveMethodToken_raw (int,int,int,int,int,int);
void ves_icall_RuntimePropertyInfo_get_property_info_raw (int,int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_RuntimePropertyInfo_internal_from_handle_type_raw (int,int,int);
void ves_icall_DynamicMethod_create_dynamic_method_raw (int,int,int,int,int);
void ves_icall_AssemblyBuilder_basic_init_raw (int,int);
void ves_icall_AssemblyBuilder_UpdateNativeCustomAttributes_raw (int,int);
void ves_icall_ModuleBuilder_basic_init_raw (int,int);
void ves_icall_ModuleBuilder_set_wrappers_type_raw (int,int,int);
int ves_icall_ModuleBuilder_getUSIndex_raw (int,int,int);
int ves_icall_ModuleBuilder_getToken_raw (int,int,int,int);
int ves_icall_ModuleBuilder_getMethodToken_raw (int,int,int,int);
void ves_icall_ModuleBuilder_RegisterToken_raw (int,int,int,int);
int ves_icall_TypeBuilder_create_runtime_class_raw (int,int);
int ves_icall_System_IO_Stream_HasOverriddenBeginEndRead_raw (int,int);
int ves_icall_System_IO_Stream_HasOverriddenBeginEndWrite_raw (int,int);
void ves_icall_System_Diagnostics_Debugger_Log (int,int,int);
int ves_icall_System_Diagnostics_StackFrame_GetFrameInfo (int,int,int,int,int,int,int,int);
void ves_icall_System_Diagnostics_StackTrace_GetTrace (int,int,int,int);
int ves_icall_Mono_RuntimeClassHandle_GetTypeFromClass (int);
void ves_icall_Mono_RuntimeGPtrArrayHandle_GPtrArrayFree (int);
int ves_icall_Mono_SafeStringMarshal_StringToUtf8 (int);
void ves_icall_Mono_SafeStringMarshal_GFree (int);
static void *corlib_icall_funcs [] = {
// token 224,
ves_icall_System_Array_InternalCreate,
// token 236,
ves_icall_System_Array_GetCorElementTypeOfElementTypeInternal,
// token 237,
ves_icall_System_Array_IsValueOfElementTypeInternal,
// token 238,
ves_icall_System_Array_CanChangePrimitive,
// token 239,
ves_icall_System_Array_FastCopy,
// token 240,
ves_icall_System_Array_GetLengthInternal_raw,
// token 241,
ves_icall_System_Array_GetLowerBoundInternal_raw,
// token 242,
ves_icall_System_Array_GetGenericValue_icall,
// token 243,
ves_icall_System_Array_GetValueImpl_raw,
// token 244,
ves_icall_System_Array_SetGenericValue_icall,
// token 247,
ves_icall_System_Array_SetValueImpl_raw,
// token 248,
ves_icall_System_Array_InitializeInternal_raw,
// token 249,
ves_icall_System_Array_SetValueRelaxedImpl_raw,
// token 419,
ves_icall_System_Runtime_RuntimeImports_ZeroMemory,
// token 420,
ves_icall_System_Runtime_RuntimeImports_Memmove,
// token 421,
ves_icall_System_Buffer_BulkMoveWithWriteBarrier,
// token 450,
ves_icall_System_Delegate_AllocDelegateLike_internal_raw,
// token 451,
ves_icall_System_Delegate_CreateDelegate_internal_raw,
// token 452,
ves_icall_System_Delegate_GetVirtualMethod_internal_raw,
// token 472,
ves_icall_System_Enum_GetEnumValuesAndNames_raw,
// token 473,
ves_icall_System_Enum_InternalBoxEnum_raw,
// token 474,
ves_icall_System_Enum_InternalGetCorElementType,
// token 475,
ves_icall_System_Enum_InternalGetUnderlyingType_raw,
// token 592,
ves_icall_System_Environment_get_ProcessorCount,
// token 593,
ves_icall_System_Environment_get_TickCount,
// token 594,
ves_icall_System_Environment_get_TickCount64,
// token 597,
ves_icall_System_Environment_FailFast_raw,
// token 635,
ves_icall_System_GC_register_ephemeron_array_raw,
// token 636,
ves_icall_System_GC_get_ephemeron_tombstone_raw,
// token 638,
ves_icall_System_GC_SuppressFinalize_raw,
// token 640,
ves_icall_System_GC_ReRegisterForFinalize_raw,
// token 642,
ves_icall_System_GC_GetGCMemoryInfo,
// token 644,
ves_icall_System_GC_AllocPinnedArray_raw,
// token 649,
ves_icall_System_Object_MemberwiseClone_raw,
// token 657,
ves_icall_System_Math_Acos,
// token 658,
ves_icall_System_Math_Acosh,
// token 659,
ves_icall_System_Math_Asin,
// token 660,
ves_icall_System_Math_Asinh,
// token 661,
ves_icall_System_Math_Atan,
// token 662,
ves_icall_System_Math_Atan2,
// token 663,
ves_icall_System_Math_Atanh,
// token 664,
ves_icall_System_Math_Cbrt,
// token 665,
ves_icall_System_Math_Ceiling,
// token 666,
ves_icall_System_Math_Cos,
// token 667,
ves_icall_System_Math_Cosh,
// token 668,
ves_icall_System_Math_Exp,
// token 669,
ves_icall_System_Math_Floor,
// token 670,
ves_icall_System_Math_Log,
// token 671,
ves_icall_System_Math_Log10,
// token 672,
ves_icall_System_Math_Pow,
// token 673,
ves_icall_System_Math_Sin,
// token 675,
ves_icall_System_Math_Sinh,
// token 676,
ves_icall_System_Math_Sqrt,
// token 677,
ves_icall_System_Math_Tan,
// token 678,
ves_icall_System_Math_Tanh,
// token 679,
ves_icall_System_Math_FusedMultiplyAdd,
// token 680,
ves_icall_System_Math_Log2,
// token 681,
ves_icall_System_Math_ModF,
// token 778,
ves_icall_System_MathF_Acos,
// token 779,
ves_icall_System_MathF_Acosh,
// token 780,
ves_icall_System_MathF_Asin,
// token 781,
ves_icall_System_MathF_Asinh,
// token 782,
ves_icall_System_MathF_Atan,
// token 783,
ves_icall_System_MathF_Atan2,
// token 784,
ves_icall_System_MathF_Atanh,
// token 785,
ves_icall_System_MathF_Cbrt,
// token 786,
ves_icall_System_MathF_Ceiling,
// token 787,
ves_icall_System_MathF_Cos,
// token 788,
ves_icall_System_MathF_Cosh,
// token 789,
ves_icall_System_MathF_Exp,
// token 790,
ves_icall_System_MathF_Floor,
// token 791,
ves_icall_System_MathF_Log,
// token 792,
ves_icall_System_MathF_Log10,
// token 793,
ves_icall_System_MathF_Pow,
// token 794,
ves_icall_System_MathF_Sin,
// token 796,
ves_icall_System_MathF_Sinh,
// token 797,
ves_icall_System_MathF_Sqrt,
// token 798,
ves_icall_System_MathF_Tan,
// token 799,
ves_icall_System_MathF_Tanh,
// token 800,
ves_icall_System_MathF_FusedMultiplyAdd,
// token 801,
ves_icall_System_MathF_Log2,
// token 802,
ves_icall_System_MathF_ModF,
// token 869,
ves_icall_RuntimeMethodHandle_ReboxFromNullable_raw,
// token 870,
ves_icall_RuntimeMethodHandle_ReboxToNullable_raw,
// token 938,
ves_icall_RuntimeType_GetCorrespondingInflatedMethod_raw,
// token 944,
ves_icall_RuntimeType_make_array_type_raw,
// token 947,
ves_icall_RuntimeType_make_byref_type_raw,
// token 949,
ves_icall_RuntimeType_make_pointer_type_raw,
// token 954,
ves_icall_RuntimeType_MakeGenericType_raw,
// token 955,
ves_icall_RuntimeType_GetMethodsByName_native_raw,
// token 957,
ves_icall_RuntimeType_GetPropertiesByName_native_raw,
// token 958,
ves_icall_RuntimeType_GetConstructors_native_raw,
// token 962,
ves_icall_RuntimeType_GetInterfaceMapData_raw,
// token 964,
ves_icall_System_RuntimeType_CreateInstanceInternal_raw,
// token 965,
ves_icall_System_RuntimeType_AllocateValueType_raw,
// token 967,
ves_icall_RuntimeType_GetDeclaringMethod_raw,
// token 969,
ves_icall_System_RuntimeType_getFullName_raw,
// token 970,
ves_icall_RuntimeType_GetGenericArgumentsInternal_raw,
// token 973,
ves_icall_RuntimeType_GetGenericParameterPosition,
// token 974,
ves_icall_RuntimeType_GetEvents_native_raw,
// token 975,
ves_icall_RuntimeType_GetFields_native_raw,
// token 978,
ves_icall_RuntimeType_GetInterfaces_raw,
// token 980,
ves_icall_RuntimeType_GetNestedTypes_native_raw,
// token 983,
ves_icall_RuntimeType_GetDeclaringType_raw,
// token 985,
ves_icall_RuntimeType_GetName_raw,
// token 987,
ves_icall_RuntimeType_GetNamespace_raw,
// token 996,
ves_icall_RuntimeType_FunctionPointerReturnAndParameterTypes_raw,
// token 1064,
ves_icall_RuntimeTypeHandle_GetAttributes,
// token 1066,
ves_icall_RuntimeTypeHandle_GetMetadataToken_raw,
// token 1068,
ves_icall_RuntimeTypeHandle_GetGenericTypeDefinition_impl_raw,
// token 1078,
ves_icall_RuntimeTypeHandle_GetCorElementType,
// token 1079,
ves_icall_RuntimeTypeHandle_HasInstantiation,
// token 1080,
ves_icall_RuntimeTypeHandle_IsComObject_raw,
// token 1081,
ves_icall_RuntimeTypeHandle_IsInstanceOfType_raw,
// token 1083,
ves_icall_RuntimeTypeHandle_HasReferences_raw,
// token 1090,
ves_icall_RuntimeTypeHandle_GetArrayRank_raw,
// token 1091,
ves_icall_RuntimeTypeHandle_GetAssembly_raw,
// token 1092,
ves_icall_RuntimeTypeHandle_GetElementType_raw,
// token 1093,
ves_icall_RuntimeTypeHandle_GetModule_raw,
// token 1094,
ves_icall_RuntimeTypeHandle_GetBaseType_raw,
// token 1102,
ves_icall_RuntimeTypeHandle_type_is_assignable_from_raw,
// token 1103,
ves_icall_RuntimeTypeHandle_IsGenericTypeDefinition,
// token 1104,
ves_icall_RuntimeTypeHandle_GetGenericParameterInfo_raw,
// token 1108,
ves_icall_RuntimeTypeHandle_is_subclass_of_raw,
// token 1109,
ves_icall_RuntimeTypeHandle_IsByRefLike_raw,
// token 1111,
ves_icall_System_RuntimeTypeHandle_internal_from_name_raw,
// token 1115,
ves_icall_System_String_FastAllocateString_raw,
// token 1116,
ves_icall_System_String_InternalIsInterned_raw,
// token 1117,
ves_icall_System_String_InternalIntern_raw,
// token 1396,
ves_icall_System_Type_internal_from_handle_raw,
// token 1588,
ves_icall_System_ValueType_InternalGetHashCode_raw,
// token 1589,
ves_icall_System_ValueType_Equals_raw,
// token 9423,
ves_icall_System_Threading_Interlocked_CompareExchange_Int,
// token 9424,
ves_icall_System_Threading_Interlocked_CompareExchange_Object,
// token 9426,
ves_icall_System_Threading_Interlocked_Decrement_Int,
// token 9427,
ves_icall_System_Threading_Interlocked_Increment_Int,
// token 9428,
ves_icall_System_Threading_Interlocked_Increment_Long,
// token 9429,
ves_icall_System_Threading_Interlocked_Exchange_Int,
// token 9430,
ves_icall_System_Threading_Interlocked_Exchange_Object,
// token 9432,
ves_icall_System_Threading_Interlocked_CompareExchange_Long,
// token 9434,
ves_icall_System_Threading_Interlocked_Exchange_Long,
// token 9436,
ves_icall_System_Threading_Interlocked_Read_Long,
// token 9437,
ves_icall_System_Threading_Interlocked_Add_Int,
// token 9438,
ves_icall_System_Threading_Interlocked_Add_Long,
// token 9449,
ves_icall_System_Threading_Monitor_Monitor_Enter_raw,
// token 9451,
mono_monitor_exit_icall_raw,
// token 9456,
ves_icall_System_Threading_Monitor_Monitor_pulse_raw,
// token 9458,
ves_icall_System_Threading_Monitor_Monitor_pulse_all_raw,
// token 9460,
ves_icall_System_Threading_Monitor_Monitor_wait_raw,
// token 9462,
ves_icall_System_Threading_Monitor_Monitor_try_enter_with_atomic_var_raw,
// token 9511,
ves_icall_System_Threading_Thread_StartInternal_raw,
// token 9517,
ves_icall_System_Threading_Thread_InitInternal_raw,
// token 9518,
ves_icall_System_Threading_Thread_GetCurrentThread,
// token 9520,
ves_icall_System_Threading_InternalThread_Thread_free_internal_raw,
// token 9521,
ves_icall_System_Threading_Thread_GetState_raw,
// token 9522,
ves_icall_System_Threading_Thread_SetState_raw,
// token 9523,
ves_icall_System_Threading_Thread_ClrState_raw,
// token 9524,
ves_icall_System_Threading_Thread_SetName_icall_raw,
// token 9526,
ves_icall_System_Threading_Thread_YieldInternal,
// token 9528,
ves_icall_System_Threading_Thread_SetPriority_raw,
// token 10592,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_PrepareForAssemblyLoadContextRelease_raw,
// token 10596,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_GetLoadContextForAssembly_raw,
// token 10598,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFile_raw,
// token 10599,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalInitializeNativeALC_raw,
// token 10600,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFromStream_raw,
// token 10601,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalGetLoadedAssemblies_raw,
// token 10859,
ves_icall_System_GCHandle_InternalAlloc_raw,
// token 10860,
ves_icall_System_GCHandle_InternalFree_raw,
// token 10861,
ves_icall_System_GCHandle_InternalGet_raw,
// token 10862,
ves_icall_System_GCHandle_InternalSet_raw,
// token 10882,
ves_icall_System_Runtime_InteropServices_Marshal_GetLastPInvokeError,
// token 10883,
ves_icall_System_Runtime_InteropServices_Marshal_SetLastPInvokeError,
// token 10884,
ves_icall_System_Runtime_InteropServices_Marshal_StructureToPtr_raw,
// token 10886,
ves_icall_System_Runtime_InteropServices_Marshal_SizeOfHelper_raw,
// token 10931,
ves_icall_System_Runtime_InteropServices_NativeLibrary_LoadByName_raw,
// token 10993,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalGetHashCode_raw,
// token 10995,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalTryGetHashCode_raw,
// token 10997,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetObjectValue_raw,
// token 11007,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetUninitializedObjectInternal_raw,
// token 11008,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InitializeArray_raw,
// token 11009,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetSpanDataFrom_raw,
// token 11010,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_RunClassConstructor_raw,
// token 11011,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_SufficientExecutionStack,
// token 11485,
ves_icall_System_Reflection_Assembly_GetExecutingAssembly_raw,
// token 11486,
ves_icall_System_Reflection_Assembly_GetEntryAssembly_raw,
// token 11490,
ves_icall_System_Reflection_Assembly_InternalLoad_raw,
// token 11491,
ves_icall_System_Reflection_Assembly_InternalGetType_raw,
// token 11524,
ves_icall_System_Reflection_AssemblyName_GetNativeName,
// token 11559,
ves_icall_MonoCustomAttrs_GetCustomAttributesInternal_raw,
// token 11566,
ves_icall_MonoCustomAttrs_GetCustomAttributesDataInternal_raw,
// token 11573,
ves_icall_MonoCustomAttrs_IsDefinedInternal_raw,
// token 11584,
ves_icall_System_Reflection_FieldInfo_internal_from_handle_type_raw,
// token 11588,
ves_icall_System_Reflection_FieldInfo_get_marshal_info_raw,
// token 11611,
ves_icall_System_Reflection_LoaderAllocatorScout_Destroy,
// token 11693,
ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceNames_raw,
// token 11695,
ves_icall_System_Reflection_RuntimeAssembly_GetExportedTypes_raw,
// token 11705,
ves_icall_System_Reflection_RuntimeAssembly_GetInfo_raw,
// token 11707,
ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInternal_raw,
// token 11708,
ves_icall_System_Reflection_Assembly_GetManifestModuleInternal_raw,
// token 11709,
ves_icall_System_Reflection_RuntimeAssembly_GetModulesInternal_raw,
// token 11716,
ves_icall_System_Reflection_RuntimeCustomAttributeData_ResolveArgumentsInternal_raw,
// token 11731,
ves_icall_RuntimeEventInfo_get_event_info_raw,
// token 11751,
ves_icall_reflection_get_token_raw,
// token 11752,
ves_icall_System_Reflection_EventInfo_internal_from_handle_type_raw,
// token 11760,
ves_icall_RuntimeFieldInfo_ResolveType_raw,
// token 11762,
ves_icall_RuntimeFieldInfo_GetParentType_raw,
// token 11769,
ves_icall_RuntimeFieldInfo_GetFieldOffset_raw,
// token 11770,
ves_icall_RuntimeFieldInfo_GetValueInternal_raw,
// token 11773,
ves_icall_RuntimeFieldInfo_SetValueInternal_raw,
// token 11775,
ves_icall_RuntimeFieldInfo_GetRawConstantValue_raw,
// token 11780,
ves_icall_reflection_get_token_raw,
// token 11786,
ves_icall_get_method_info_raw,
// token 11787,
ves_icall_get_method_attributes,
// token 11794,
ves_icall_System_Reflection_MonoMethodInfo_get_parameter_info_raw,
// token 11796,
ves_icall_System_MonoMethodInfo_get_retval_marshal_raw,
// token 11808,
ves_icall_System_Reflection_RuntimeMethodInfo_GetMethodFromHandleInternalType_native_raw,
// token 11811,
ves_icall_RuntimeMethodInfo_get_name_raw,
// token 11812,
ves_icall_RuntimeMethodInfo_get_base_method_raw,
// token 11813,
ves_icall_reflection_get_token_raw,
// token 11824,
ves_icall_InternalInvoke_raw,
// token 11833,
ves_icall_RuntimeMethodInfo_GetPInvoke_raw,
// token 11839,
ves_icall_RuntimeMethodInfo_MakeGenericMethod_impl_raw,
// token 11840,
ves_icall_RuntimeMethodInfo_GetGenericArguments_raw,
// token 11841,
ves_icall_RuntimeMethodInfo_GetGenericMethodDefinition_raw,
// token 11843,
ves_icall_RuntimeMethodInfo_get_IsGenericMethodDefinition_raw,
// token 11844,
ves_icall_RuntimeMethodInfo_get_IsGenericMethod_raw,
// token 11861,
ves_icall_InvokeClassConstructor_raw,
// token 11863,
ves_icall_InternalInvoke_raw,
// token 11877,
ves_icall_reflection_get_token_raw,
// token 11897,
ves_icall_System_Reflection_RuntimeModule_InternalGetTypes_raw,
// token 11898,
ves_icall_System_Reflection_RuntimeModule_ResolveMethodToken_raw,
// token 11925,
ves_icall_RuntimePropertyInfo_get_property_info_raw,
// token 11955,
ves_icall_reflection_get_token_raw,
// token 11956,
ves_icall_System_Reflection_RuntimePropertyInfo_internal_from_handle_type_raw,
// token 12563,
ves_icall_DynamicMethod_create_dynamic_method_raw,
// token 12656,
ves_icall_AssemblyBuilder_basic_init_raw,
// token 12657,
ves_icall_AssemblyBuilder_UpdateNativeCustomAttributes_raw,
// token 12867,
ves_icall_ModuleBuilder_basic_init_raw,
// token 12868,
ves_icall_ModuleBuilder_set_wrappers_type_raw,
// token 12876,
ves_icall_ModuleBuilder_getUSIndex_raw,
// token 12877,
ves_icall_ModuleBuilder_getToken_raw,
// token 12878,
ves_icall_ModuleBuilder_getMethodToken_raw,
// token 12883,
ves_icall_ModuleBuilder_RegisterToken_raw,
// token 12961,
ves_icall_TypeBuilder_create_runtime_class_raw,
// token 13434,
ves_icall_System_IO_Stream_HasOverriddenBeginEndRead_raw,
// token 13435,
ves_icall_System_IO_Stream_HasOverriddenBeginEndWrite_raw,
// token 13842,
ves_icall_System_Diagnostics_Debugger_Log,
// token 13847,
ves_icall_System_Diagnostics_StackFrame_GetFrameInfo,
// token 13857,
ves_icall_System_Diagnostics_StackTrace_GetTrace,
// token 15224,
ves_icall_Mono_RuntimeClassHandle_GetTypeFromClass,
// token 15245,
ves_icall_Mono_RuntimeGPtrArrayHandle_GPtrArrayFree,
// token 15247,
ves_icall_Mono_SafeStringMarshal_StringToUtf8,
// token 15249,
ves_icall_Mono_SafeStringMarshal_GFree,
};
static uint8_t corlib_icall_flags [] = {
0,
0,
0,
0,
0,
4,
4,
0,
4,
0,
4,
4,
4,
0,
0,
0,
4,
4,
4,
4,
4,
0,
4,
0,
0,
0,
4,
4,
4,
4,
4,
0,
4,
4,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
4,
0,
0,
0,
0,
0,
0,
0,
};
