#define ICALL_TABLE_corlib 1

static int corlib_icall_indexes [] = {
244,
256,
257,
258,
259,
260,
261,
262,
263,
264,
267,
268,
269,
446,
447,
448,
478,
479,
480,
500,
501,
502,
503,
620,
621,
622,
625,
676,
677,
678,
679,
680,
685,
687,
689,
691,
696,
704,
705,
706,
707,
708,
709,
710,
711,
712,
713,
714,
715,
716,
717,
718,
719,
720,
722,
723,
724,
725,
726,
727,
728,
826,
827,
828,
829,
830,
831,
832,
833,
834,
835,
836,
837,
838,
839,
840,
841,
842,
844,
845,
846,
847,
848,
849,
850,
917,
918,
988,
995,
998,
1000,
1005,
1006,
1008,
1009,
1013,
1015,
1016,
1018,
1020,
1021,
1024,
1025,
1026,
1029,
1031,
1034,
1036,
1038,
1047,
1116,
1118,
1120,
1130,
1131,
1132,
1133,
1135,
1142,
1143,
1144,
1145,
1146,
1154,
1155,
1156,
1160,
1161,
1163,
1167,
1168,
1169,
1453,
1655,
1656,
10274,
10275,
10277,
10278,
10279,
10280,
10281,
10282,
10284,
10286,
10288,
10289,
10290,
10301,
10303,
10310,
10312,
10314,
10316,
10368,
10374,
10375,
10377,
10378,
10379,
10380,
10381,
10383,
10385,
10386,
11609,
11613,
11615,
11616,
11617,
11618,
11918,
11919,
11920,
11921,
11942,
11943,
11944,
11946,
11993,
12069,
12071,
12073,
12083,
12084,
12085,
12086,
12087,
12573,
12574,
12575,
12580,
12581,
12623,
12624,
12661,
12668,
12675,
12686,
12690,
12716,
12741,
12803,
12805,
12819,
12821,
12822,
12823,
12824,
12825,
12832,
12847,
12867,
12868,
12876,
12878,
12885,
12886,
12889,
12891,
12896,
12902,
12903,
12910,
12912,
12924,
12927,
12928,
12929,
12940,
12949,
12955,
12956,
12957,
12959,
12960,
12977,
12979,
12993,
13016,
13017,
13018,
13043,
13048,
13079,
13080,
13743,
13761,
13857,
13858,
14090,
14091,
14099,
14100,
14101,
14107,
14219,
14946,
14947,
15633,
15635,
15636,
15641,
15652,
17075,
17096,
17098,
17100,
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
int ves_icall_System_GC_GetCollectionCount (int);
void ves_icall_System_GC_AddPressure (uint64_t);
void ves_icall_System_GC_RemovePressure (uint64_t);
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
int64_t ves_icall_System_Threading_Interlocked_Decrement_Long (int);
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
int ves_icall_System_Threading_Thread_Join_internal_raw (int,int,int);
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
int ves_icall_System_Reflection_Assembly_GetCallingAssembly_raw (int);
int ves_icall_System_Reflection_Assembly_GetEntryAssembly_raw (int);
int ves_icall_System_Reflection_Assembly_InternalLoad_raw (int,int,int,int);
int ves_icall_System_Reflection_Assembly_InternalGetType_raw (int,int,int,int,int,int);
void ves_icall_System_Reflection_AssemblyName_FreeAssemblyName (int,int);
int ves_icall_System_Reflection_AssemblyName_GetNativeName (int);
int ves_icall_MonoCustomAttrs_GetCustomAttributesInternal_raw (int,int,int,int);
int ves_icall_MonoCustomAttrs_GetCustomAttributesDataInternal_raw (int,int);
int ves_icall_MonoCustomAttrs_IsDefinedInternal_raw (int,int,int);
int ves_icall_System_Reflection_FieldInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_System_Reflection_FieldInfo_get_marshal_info_raw (int,int);
int ves_icall_System_Reflection_LoaderAllocatorScout_Destroy (int);
int ves_icall_GetCurrentMethod_raw (int);
void ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceNames_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetExportedTypes_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetInfo_raw (int,int,int,int);
int ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInfoInternal_raw (int,int,int,int);
int ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInternal_raw (int,int,int,int,int);
void ves_icall_System_Reflection_Assembly_GetManifestModuleInternal_raw (int,int,int);
void ves_icall_System_Reflection_RuntimeAssembly_GetModulesInternal_raw (int,int,int);
int ves_icall_System_Reflection_Assembly_InternalGetReferencedAssemblies_raw (int,int);
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
void ves_icall_System_Reflection_RuntimeModule_GetGuidInternal_raw (int,int,int);
int ves_icall_System_Reflection_RuntimeModule_ResolveMethodToken_raw (int,int,int,int,int,int);
int ves_icall_RuntimeParameterInfo_GetTypeModifiers_raw (int,int,int,int,int,int);
void ves_icall_RuntimePropertyInfo_get_property_info_raw (int,int,int,int);
int ves_icall_reflection_get_token_raw (int,int);
int ves_icall_System_Reflection_RuntimePropertyInfo_internal_from_handle_type_raw (int,int,int);
int ves_icall_CustomAttributeBuilder_GetBlob_raw (int,int,int,int,int,int,int,int);
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
int ves_icall_System_Diagnostics_Debugger_IsAttached_internal ();
int ves_icall_System_Diagnostics_Debugger_IsLogging ();
void ves_icall_System_Diagnostics_Debugger_Log (int,int,int);
int ves_icall_System_Diagnostics_StackFrame_GetFrameInfo (int,int,int,int,int,int,int,int);
void ves_icall_System_Diagnostics_StackTrace_GetTrace (int,int,int,int);
int ves_icall_Mono_RuntimeClassHandle_GetTypeFromClass (int);
void ves_icall_Mono_RuntimeGPtrArrayHandle_GPtrArrayFree (int);
int ves_icall_Mono_SafeStringMarshal_StringToUtf8 (int);
void ves_icall_Mono_SafeStringMarshal_GFree (int);
static void *corlib_icall_funcs [] = {
// token 244,
ves_icall_System_Array_InternalCreate,
// token 256,
ves_icall_System_Array_GetCorElementTypeOfElementTypeInternal,
// token 257,
ves_icall_System_Array_IsValueOfElementTypeInternal,
// token 258,
ves_icall_System_Array_CanChangePrimitive,
// token 259,
ves_icall_System_Array_FastCopy,
// token 260,
ves_icall_System_Array_GetLengthInternal_raw,
// token 261,
ves_icall_System_Array_GetLowerBoundInternal_raw,
// token 262,
ves_icall_System_Array_GetGenericValue_icall,
// token 263,
ves_icall_System_Array_GetValueImpl_raw,
// token 264,
ves_icall_System_Array_SetGenericValue_icall,
// token 267,
ves_icall_System_Array_SetValueImpl_raw,
// token 268,
ves_icall_System_Array_InitializeInternal_raw,
// token 269,
ves_icall_System_Array_SetValueRelaxedImpl_raw,
// token 446,
ves_icall_System_Runtime_RuntimeImports_ZeroMemory,
// token 447,
ves_icall_System_Runtime_RuntimeImports_Memmove,
// token 448,
ves_icall_System_Buffer_BulkMoveWithWriteBarrier,
// token 478,
ves_icall_System_Delegate_AllocDelegateLike_internal_raw,
// token 479,
ves_icall_System_Delegate_CreateDelegate_internal_raw,
// token 480,
ves_icall_System_Delegate_GetVirtualMethod_internal_raw,
// token 500,
ves_icall_System_Enum_GetEnumValuesAndNames_raw,
// token 501,
ves_icall_System_Enum_InternalBoxEnum_raw,
// token 502,
ves_icall_System_Enum_InternalGetCorElementType,
// token 503,
ves_icall_System_Enum_InternalGetUnderlyingType_raw,
// token 620,
ves_icall_System_Environment_get_ProcessorCount,
// token 621,
ves_icall_System_Environment_get_TickCount,
// token 622,
ves_icall_System_Environment_get_TickCount64,
// token 625,
ves_icall_System_Environment_FailFast_raw,
// token 676,
ves_icall_System_GC_GetCollectionCount,
// token 677,
ves_icall_System_GC_AddPressure,
// token 678,
ves_icall_System_GC_RemovePressure,
// token 679,
ves_icall_System_GC_register_ephemeron_array_raw,
// token 680,
ves_icall_System_GC_get_ephemeron_tombstone_raw,
// token 685,
ves_icall_System_GC_SuppressFinalize_raw,
// token 687,
ves_icall_System_GC_ReRegisterForFinalize_raw,
// token 689,
ves_icall_System_GC_GetGCMemoryInfo,
// token 691,
ves_icall_System_GC_AllocPinnedArray_raw,
// token 696,
ves_icall_System_Object_MemberwiseClone_raw,
// token 704,
ves_icall_System_Math_Acos,
// token 705,
ves_icall_System_Math_Acosh,
// token 706,
ves_icall_System_Math_Asin,
// token 707,
ves_icall_System_Math_Asinh,
// token 708,
ves_icall_System_Math_Atan,
// token 709,
ves_icall_System_Math_Atan2,
// token 710,
ves_icall_System_Math_Atanh,
// token 711,
ves_icall_System_Math_Cbrt,
// token 712,
ves_icall_System_Math_Ceiling,
// token 713,
ves_icall_System_Math_Cos,
// token 714,
ves_icall_System_Math_Cosh,
// token 715,
ves_icall_System_Math_Exp,
// token 716,
ves_icall_System_Math_Floor,
// token 717,
ves_icall_System_Math_Log,
// token 718,
ves_icall_System_Math_Log10,
// token 719,
ves_icall_System_Math_Pow,
// token 720,
ves_icall_System_Math_Sin,
// token 722,
ves_icall_System_Math_Sinh,
// token 723,
ves_icall_System_Math_Sqrt,
// token 724,
ves_icall_System_Math_Tan,
// token 725,
ves_icall_System_Math_Tanh,
// token 726,
ves_icall_System_Math_FusedMultiplyAdd,
// token 727,
ves_icall_System_Math_Log2,
// token 728,
ves_icall_System_Math_ModF,
// token 826,
ves_icall_System_MathF_Acos,
// token 827,
ves_icall_System_MathF_Acosh,
// token 828,
ves_icall_System_MathF_Asin,
// token 829,
ves_icall_System_MathF_Asinh,
// token 830,
ves_icall_System_MathF_Atan,
// token 831,
ves_icall_System_MathF_Atan2,
// token 832,
ves_icall_System_MathF_Atanh,
// token 833,
ves_icall_System_MathF_Cbrt,
// token 834,
ves_icall_System_MathF_Ceiling,
// token 835,
ves_icall_System_MathF_Cos,
// token 836,
ves_icall_System_MathF_Cosh,
// token 837,
ves_icall_System_MathF_Exp,
// token 838,
ves_icall_System_MathF_Floor,
// token 839,
ves_icall_System_MathF_Log,
// token 840,
ves_icall_System_MathF_Log10,
// token 841,
ves_icall_System_MathF_Pow,
// token 842,
ves_icall_System_MathF_Sin,
// token 844,
ves_icall_System_MathF_Sinh,
// token 845,
ves_icall_System_MathF_Sqrt,
// token 846,
ves_icall_System_MathF_Tan,
// token 847,
ves_icall_System_MathF_Tanh,
// token 848,
ves_icall_System_MathF_FusedMultiplyAdd,
// token 849,
ves_icall_System_MathF_Log2,
// token 850,
ves_icall_System_MathF_ModF,
// token 917,
ves_icall_RuntimeMethodHandle_ReboxFromNullable_raw,
// token 918,
ves_icall_RuntimeMethodHandle_ReboxToNullable_raw,
// token 988,
ves_icall_RuntimeType_GetCorrespondingInflatedMethod_raw,
// token 995,
ves_icall_RuntimeType_make_array_type_raw,
// token 998,
ves_icall_RuntimeType_make_byref_type_raw,
// token 1000,
ves_icall_RuntimeType_make_pointer_type_raw,
// token 1005,
ves_icall_RuntimeType_MakeGenericType_raw,
// token 1006,
ves_icall_RuntimeType_GetMethodsByName_native_raw,
// token 1008,
ves_icall_RuntimeType_GetPropertiesByName_native_raw,
// token 1009,
ves_icall_RuntimeType_GetConstructors_native_raw,
// token 1013,
ves_icall_RuntimeType_GetInterfaceMapData_raw,
// token 1015,
ves_icall_System_RuntimeType_CreateInstanceInternal_raw,
// token 1016,
ves_icall_System_RuntimeType_AllocateValueType_raw,
// token 1018,
ves_icall_RuntimeType_GetDeclaringMethod_raw,
// token 1020,
ves_icall_System_RuntimeType_getFullName_raw,
// token 1021,
ves_icall_RuntimeType_GetGenericArgumentsInternal_raw,
// token 1024,
ves_icall_RuntimeType_GetGenericParameterPosition,
// token 1025,
ves_icall_RuntimeType_GetEvents_native_raw,
// token 1026,
ves_icall_RuntimeType_GetFields_native_raw,
// token 1029,
ves_icall_RuntimeType_GetInterfaces_raw,
// token 1031,
ves_icall_RuntimeType_GetNestedTypes_native_raw,
// token 1034,
ves_icall_RuntimeType_GetDeclaringType_raw,
// token 1036,
ves_icall_RuntimeType_GetName_raw,
// token 1038,
ves_icall_RuntimeType_GetNamespace_raw,
// token 1047,
ves_icall_RuntimeType_FunctionPointerReturnAndParameterTypes_raw,
// token 1116,
ves_icall_RuntimeTypeHandle_GetAttributes,
// token 1118,
ves_icall_RuntimeTypeHandle_GetMetadataToken_raw,
// token 1120,
ves_icall_RuntimeTypeHandle_GetGenericTypeDefinition_impl_raw,
// token 1130,
ves_icall_RuntimeTypeHandle_GetCorElementType,
// token 1131,
ves_icall_RuntimeTypeHandle_HasInstantiation,
// token 1132,
ves_icall_RuntimeTypeHandle_IsComObject_raw,
// token 1133,
ves_icall_RuntimeTypeHandle_IsInstanceOfType_raw,
// token 1135,
ves_icall_RuntimeTypeHandle_HasReferences_raw,
// token 1142,
ves_icall_RuntimeTypeHandle_GetArrayRank_raw,
// token 1143,
ves_icall_RuntimeTypeHandle_GetAssembly_raw,
// token 1144,
ves_icall_RuntimeTypeHandle_GetElementType_raw,
// token 1145,
ves_icall_RuntimeTypeHandle_GetModule_raw,
// token 1146,
ves_icall_RuntimeTypeHandle_GetBaseType_raw,
// token 1154,
ves_icall_RuntimeTypeHandle_type_is_assignable_from_raw,
// token 1155,
ves_icall_RuntimeTypeHandle_IsGenericTypeDefinition,
// token 1156,
ves_icall_RuntimeTypeHandle_GetGenericParameterInfo_raw,
// token 1160,
ves_icall_RuntimeTypeHandle_is_subclass_of_raw,
// token 1161,
ves_icall_RuntimeTypeHandle_IsByRefLike_raw,
// token 1163,
ves_icall_System_RuntimeTypeHandle_internal_from_name_raw,
// token 1167,
ves_icall_System_String_FastAllocateString_raw,
// token 1168,
ves_icall_System_String_InternalIsInterned_raw,
// token 1169,
ves_icall_System_String_InternalIntern_raw,
// token 1453,
ves_icall_System_Type_internal_from_handle_raw,
// token 1655,
ves_icall_System_ValueType_InternalGetHashCode_raw,
// token 1656,
ves_icall_System_ValueType_Equals_raw,
// token 10274,
ves_icall_System_Threading_Interlocked_CompareExchange_Int,
// token 10275,
ves_icall_System_Threading_Interlocked_CompareExchange_Object,
// token 10277,
ves_icall_System_Threading_Interlocked_Decrement_Int,
// token 10278,
ves_icall_System_Threading_Interlocked_Decrement_Long,
// token 10279,
ves_icall_System_Threading_Interlocked_Increment_Int,
// token 10280,
ves_icall_System_Threading_Interlocked_Increment_Long,
// token 10281,
ves_icall_System_Threading_Interlocked_Exchange_Int,
// token 10282,
ves_icall_System_Threading_Interlocked_Exchange_Object,
// token 10284,
ves_icall_System_Threading_Interlocked_CompareExchange_Long,
// token 10286,
ves_icall_System_Threading_Interlocked_Exchange_Long,
// token 10288,
ves_icall_System_Threading_Interlocked_Read_Long,
// token 10289,
ves_icall_System_Threading_Interlocked_Add_Int,
// token 10290,
ves_icall_System_Threading_Interlocked_Add_Long,
// token 10301,
ves_icall_System_Threading_Monitor_Monitor_Enter_raw,
// token 10303,
mono_monitor_exit_icall_raw,
// token 10310,
ves_icall_System_Threading_Monitor_Monitor_pulse_raw,
// token 10312,
ves_icall_System_Threading_Monitor_Monitor_pulse_all_raw,
// token 10314,
ves_icall_System_Threading_Monitor_Monitor_wait_raw,
// token 10316,
ves_icall_System_Threading_Monitor_Monitor_try_enter_with_atomic_var_raw,
// token 10368,
ves_icall_System_Threading_Thread_StartInternal_raw,
// token 10374,
ves_icall_System_Threading_Thread_InitInternal_raw,
// token 10375,
ves_icall_System_Threading_Thread_GetCurrentThread,
// token 10377,
ves_icall_System_Threading_InternalThread_Thread_free_internal_raw,
// token 10378,
ves_icall_System_Threading_Thread_GetState_raw,
// token 10379,
ves_icall_System_Threading_Thread_SetState_raw,
// token 10380,
ves_icall_System_Threading_Thread_ClrState_raw,
// token 10381,
ves_icall_System_Threading_Thread_SetName_icall_raw,
// token 10383,
ves_icall_System_Threading_Thread_YieldInternal,
// token 10385,
ves_icall_System_Threading_Thread_Join_internal_raw,
// token 10386,
ves_icall_System_Threading_Thread_SetPriority_raw,
// token 11609,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_PrepareForAssemblyLoadContextRelease_raw,
// token 11613,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_GetLoadContextForAssembly_raw,
// token 11615,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFile_raw,
// token 11616,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalInitializeNativeALC_raw,
// token 11617,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalLoadFromStream_raw,
// token 11618,
ves_icall_System_Runtime_Loader_AssemblyLoadContext_InternalGetLoadedAssemblies_raw,
// token 11918,
ves_icall_System_GCHandle_InternalAlloc_raw,
// token 11919,
ves_icall_System_GCHandle_InternalFree_raw,
// token 11920,
ves_icall_System_GCHandle_InternalGet_raw,
// token 11921,
ves_icall_System_GCHandle_InternalSet_raw,
// token 11942,
ves_icall_System_Runtime_InteropServices_Marshal_GetLastPInvokeError,
// token 11943,
ves_icall_System_Runtime_InteropServices_Marshal_SetLastPInvokeError,
// token 11944,
ves_icall_System_Runtime_InteropServices_Marshal_StructureToPtr_raw,
// token 11946,
ves_icall_System_Runtime_InteropServices_Marshal_SizeOfHelper_raw,
// token 11993,
ves_icall_System_Runtime_InteropServices_NativeLibrary_LoadByName_raw,
// token 12069,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalGetHashCode_raw,
// token 12071,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InternalTryGetHashCode_raw,
// token 12073,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetObjectValue_raw,
// token 12083,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetUninitializedObjectInternal_raw,
// token 12084,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_InitializeArray_raw,
// token 12085,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_GetSpanDataFrom_raw,
// token 12086,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_RunClassConstructor_raw,
// token 12087,
ves_icall_System_Runtime_CompilerServices_RuntimeHelpers_SufficientExecutionStack,
// token 12573,
ves_icall_System_Reflection_Assembly_GetExecutingAssembly_raw,
// token 12574,
ves_icall_System_Reflection_Assembly_GetCallingAssembly_raw,
// token 12575,
ves_icall_System_Reflection_Assembly_GetEntryAssembly_raw,
// token 12580,
ves_icall_System_Reflection_Assembly_InternalLoad_raw,
// token 12581,
ves_icall_System_Reflection_Assembly_InternalGetType_raw,
// token 12623,
ves_icall_System_Reflection_AssemblyName_FreeAssemblyName,
// token 12624,
ves_icall_System_Reflection_AssemblyName_GetNativeName,
// token 12661,
ves_icall_MonoCustomAttrs_GetCustomAttributesInternal_raw,
// token 12668,
ves_icall_MonoCustomAttrs_GetCustomAttributesDataInternal_raw,
// token 12675,
ves_icall_MonoCustomAttrs_IsDefinedInternal_raw,
// token 12686,
ves_icall_System_Reflection_FieldInfo_internal_from_handle_type_raw,
// token 12690,
ves_icall_System_Reflection_FieldInfo_get_marshal_info_raw,
// token 12716,
ves_icall_System_Reflection_LoaderAllocatorScout_Destroy,
// token 12741,
ves_icall_GetCurrentMethod_raw,
// token 12803,
ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceNames_raw,
// token 12805,
ves_icall_System_Reflection_RuntimeAssembly_GetExportedTypes_raw,
// token 12819,
ves_icall_System_Reflection_RuntimeAssembly_GetInfo_raw,
// token 12821,
ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInfoInternal_raw,
// token 12822,
ves_icall_System_Reflection_RuntimeAssembly_GetManifestResourceInternal_raw,
// token 12823,
ves_icall_System_Reflection_Assembly_GetManifestModuleInternal_raw,
// token 12824,
ves_icall_System_Reflection_RuntimeAssembly_GetModulesInternal_raw,
// token 12825,
ves_icall_System_Reflection_Assembly_InternalGetReferencedAssemblies_raw,
// token 12832,
ves_icall_System_Reflection_RuntimeCustomAttributeData_ResolveArgumentsInternal_raw,
// token 12847,
ves_icall_RuntimeEventInfo_get_event_info_raw,
// token 12867,
ves_icall_reflection_get_token_raw,
// token 12868,
ves_icall_System_Reflection_EventInfo_internal_from_handle_type_raw,
// token 12876,
ves_icall_RuntimeFieldInfo_ResolveType_raw,
// token 12878,
ves_icall_RuntimeFieldInfo_GetParentType_raw,
// token 12885,
ves_icall_RuntimeFieldInfo_GetFieldOffset_raw,
// token 12886,
ves_icall_RuntimeFieldInfo_GetValueInternal_raw,
// token 12889,
ves_icall_RuntimeFieldInfo_SetValueInternal_raw,
// token 12891,
ves_icall_RuntimeFieldInfo_GetRawConstantValue_raw,
// token 12896,
ves_icall_reflection_get_token_raw,
// token 12902,
ves_icall_get_method_info_raw,
// token 12903,
ves_icall_get_method_attributes,
// token 12910,
ves_icall_System_Reflection_MonoMethodInfo_get_parameter_info_raw,
// token 12912,
ves_icall_System_MonoMethodInfo_get_retval_marshal_raw,
// token 12924,
ves_icall_System_Reflection_RuntimeMethodInfo_GetMethodFromHandleInternalType_native_raw,
// token 12927,
ves_icall_RuntimeMethodInfo_get_name_raw,
// token 12928,
ves_icall_RuntimeMethodInfo_get_base_method_raw,
// token 12929,
ves_icall_reflection_get_token_raw,
// token 12940,
ves_icall_InternalInvoke_raw,
// token 12949,
ves_icall_RuntimeMethodInfo_GetPInvoke_raw,
// token 12955,
ves_icall_RuntimeMethodInfo_MakeGenericMethod_impl_raw,
// token 12956,
ves_icall_RuntimeMethodInfo_GetGenericArguments_raw,
// token 12957,
ves_icall_RuntimeMethodInfo_GetGenericMethodDefinition_raw,
// token 12959,
ves_icall_RuntimeMethodInfo_get_IsGenericMethodDefinition_raw,
// token 12960,
ves_icall_RuntimeMethodInfo_get_IsGenericMethod_raw,
// token 12977,
ves_icall_InvokeClassConstructor_raw,
// token 12979,
ves_icall_InternalInvoke_raw,
// token 12993,
ves_icall_reflection_get_token_raw,
// token 13016,
ves_icall_System_Reflection_RuntimeModule_InternalGetTypes_raw,
// token 13017,
ves_icall_System_Reflection_RuntimeModule_GetGuidInternal_raw,
// token 13018,
ves_icall_System_Reflection_RuntimeModule_ResolveMethodToken_raw,
// token 13043,
ves_icall_RuntimeParameterInfo_GetTypeModifiers_raw,
// token 13048,
ves_icall_RuntimePropertyInfo_get_property_info_raw,
// token 13079,
ves_icall_reflection_get_token_raw,
// token 13080,
ves_icall_System_Reflection_RuntimePropertyInfo_internal_from_handle_type_raw,
// token 13743,
ves_icall_CustomAttributeBuilder_GetBlob_raw,
// token 13761,
ves_icall_DynamicMethod_create_dynamic_method_raw,
// token 13857,
ves_icall_AssemblyBuilder_basic_init_raw,
// token 13858,
ves_icall_AssemblyBuilder_UpdateNativeCustomAttributes_raw,
// token 14090,
ves_icall_ModuleBuilder_basic_init_raw,
// token 14091,
ves_icall_ModuleBuilder_set_wrappers_type_raw,
// token 14099,
ves_icall_ModuleBuilder_getUSIndex_raw,
// token 14100,
ves_icall_ModuleBuilder_getToken_raw,
// token 14101,
ves_icall_ModuleBuilder_getMethodToken_raw,
// token 14107,
ves_icall_ModuleBuilder_RegisterToken_raw,
// token 14219,
ves_icall_TypeBuilder_create_runtime_class_raw,
// token 14946,
ves_icall_System_IO_Stream_HasOverriddenBeginEndRead_raw,
// token 14947,
ves_icall_System_IO_Stream_HasOverriddenBeginEndWrite_raw,
// token 15633,
ves_icall_System_Diagnostics_Debugger_IsAttached_internal,
// token 15635,
ves_icall_System_Diagnostics_Debugger_IsLogging,
// token 15636,
ves_icall_System_Diagnostics_Debugger_Log,
// token 15641,
ves_icall_System_Diagnostics_StackFrame_GetFrameInfo,
// token 15652,
ves_icall_System_Diagnostics_StackTrace_GetTrace,
// token 17075,
ves_icall_Mono_RuntimeClassHandle_GetTypeFromClass,
// token 17096,
ves_icall_Mono_RuntimeGPtrArrayHandle_GPtrArrayFree,
// token 17098,
ves_icall_Mono_SafeStringMarshal_StringToUtf8,
// token 17100,
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
0,
0,
0,
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
4,
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
};
