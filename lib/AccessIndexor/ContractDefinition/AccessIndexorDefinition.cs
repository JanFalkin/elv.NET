using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Elv.NET.Contracts.AccessIndexor.ContractDefinition
{


    public partial class AccessIndexorDeployment : AccessIndexorDeploymentBase
    {
        public AccessIndexorDeployment() : base(BYTECODE) { }
        public AccessIndexorDeployment(string byteCode) : base(byteCode) { }
    }

    public class AccessIndexorDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public AccessIndexorDeploymentBase() : base(BYTECODE) { }
        public AccessIndexorDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class CreatorFunction : CreatorFunctionBase { }

    [Function("creator", "address")]
    public class CreatorFunctionBase : FunctionMessage
    {

    }

    public partial class CleanUpContentObjectsFunction : CleanUpContentObjectsFunctionBase { }

    [Function("cleanUpContentObjects", "uint256")]
    public class CleanUpContentObjectsFunctionBase : FunctionMessage
    {

    }

    public partial class SetContentSpaceFunction : SetContentSpaceFunctionBase { }

    [Function("setContentSpace")]
    public class SetContentSpaceFunctionBase : FunctionMessage
    {
        [Parameter("address", "content_space", 1)]
        public virtual string ContentSpace { get; set; }
    }

    public partial class GetContractRightsFunction : GetContractRightsFunctionBase { }

    [Function("getContractRights", "uint8")]
    public class GetContractRightsFunctionBase : FunctionMessage
    {
        [Parameter("address", "obj", 1)]
        public virtual string Obj { get; set; }
    }

    public partial class CategoryContentObjectFunction : CategoryContentObjectFunctionBase { }

    [Function("CATEGORY_CONTENT_OBJECT", "uint8")]
    public class CategoryContentObjectFunctionBase : FunctionMessage
    {

    }

    public partial class GetAccessGroupsLengthFunction : GetAccessGroupsLengthFunctionBase { }

    [Function("getAccessGroupsLength", "uint256")]
    public class GetAccessGroupsLengthFunctionBase : FunctionMessage
    {

    }

    public partial class CategoryGroupFunction : CategoryGroupFunctionBase { }

    [Function("CATEGORY_GROUP", "uint8")]
    public class CategoryGroupFunctionBase : FunctionMessage
    {

    }

    public partial class CheckAccessGroupRightsFunction : CheckAccessGroupRightsFunctionBase { }

    [Function("checkAccessGroupRights", "bool")]
    public class CheckAccessGroupRightsFunctionBase : FunctionMessage
    {
        [Parameter("address", "group", 1)]
        public virtual string Group { get; set; }
        [Parameter("uint8", "access_type", 2)]
        public virtual byte AccessType { get; set; }
    }

    public partial class CategoryLibraryFunction : CategoryLibraryFunctionBase { }

    [Function("CATEGORY_LIBRARY", "uint8")]
    public class CategoryLibraryFunctionBase : FunctionMessage
    {

    }

    public partial class AccessConfirmedFunction : AccessConfirmedFunctionBase { }

    [Function("ACCESS_CONFIRMED", "uint8")]
    public class AccessConfirmedFunctionBase : FunctionMessage
    {

    }

    public partial class SetContractRightsFunction : SetContractRightsFunctionBase { }

    [Function("setContractRights")]
    public class SetContractRightsFunctionBase : FunctionMessage
    {
        [Parameter("address", "obj", 1)]
        public virtual string Obj { get; set; }
        [Parameter("uint8", "access_type", 2)]
        public virtual byte AccessType { get; set; }
        [Parameter("uint8", "access", 3)]
        public virtual byte Access { get; set; }
    }

    public partial class GetAccessGroupFunction : GetAccessGroupFunctionBase { }

    [Function("getAccessGroup", "address")]
    public class GetAccessGroupFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "position", 1)]
        public virtual BigInteger Position { get; set; }
    }

    public partial class CleanUpAllFunction : CleanUpAllFunctionBase { }

    [Function("cleanUpAll", typeof(CleanUpAllOutputDTO))]
    public class CleanUpAllFunctionBase : FunctionMessage
    {

    }

    public partial class GetAccessGroupRightsFunction : GetAccessGroupRightsFunctionBase { }

    [Function("getAccessGroupRights", "uint8")]
    public class GetAccessGroupRightsFunctionBase : FunctionMessage
    {
        [Parameter("address", "group", 1)]
        public virtual string Group { get; set; }
    }

    public partial class AccessGroupsFunction : AccessGroupsFunctionBase { }

    [Function("accessGroups", typeof(AccessGroupsOutputDTO))]
    public class AccessGroupsFunctionBase : FunctionMessage
    {

    }

    public partial class SetContentObjectRightsFunction : SetContentObjectRightsFunctionBase { }

    [Function("setContentObjectRights")]
    public class SetContentObjectRightsFunctionBase : FunctionMessage
    {
        [Parameter("address", "obj", 1)]
        public virtual string Obj { get; set; }
        [Parameter("uint8", "access_type", 2)]
        public virtual byte AccessType { get; set; }
        [Parameter("uint8", "access", 3)]
        public virtual byte Access { get; set; }
    }

    public partial class KillFunction : KillFunctionBase { }

    [Function("kill")]
    public class KillFunctionBase : FunctionMessage
    {

    }

    public partial class HasManagerAccessFunction : HasManagerAccessFunctionBase { }

    [Function("hasManagerAccess", "bool")]
    public class HasManagerAccessFunctionBase : FunctionMessage
    {
        [Parameter("address", "candidate", 1)]
        public virtual string Candidate { get; set; }
    }

    public partial class AccessTentativeFunction : AccessTentativeFunctionBase { }

    [Function("ACCESS_TENTATIVE", "uint8")]
    public class AccessTentativeFunctionBase : FunctionMessage
    {

    }

    public partial class OthersFunction : OthersFunctionBase { }

    [Function("others", typeof(OthersOutputDTO))]
    public class OthersFunctionBase : FunctionMessage
    {

    }

    public partial class VersionFunction : VersionFunctionBase { }

    [Function("version", "bytes32")]
    public class VersionFunctionBase : FunctionMessage
    {

    }

    public partial class GetContentTypesLengthFunction : GetContentTypesLengthFunctionBase { }

    [Function("getContentTypesLength", "uint256")]
    public class GetContentTypesLengthFunctionBase : FunctionMessage
    {

    }

    public partial class SetEntityRightsFunction : SetEntityRightsFunctionBase { }

    [Function("setEntityRights")]
    public class SetEntityRightsFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "indexType", 1)]
        public virtual byte IndexType { get; set; }
        [Parameter("address", "obj", 2)]
        public virtual string Obj { get; set; }
        [Parameter("uint8", "access_type", 3)]
        public virtual byte AccessType { get; set; }
        [Parameter("uint8", "access", 4)]
        public virtual byte Access { get; set; }
    }

    public partial class TypeEditFunction : TypeEditFunctionBase { }

    [Function("TYPE_EDIT", "uint8")]
    public class TypeEditFunctionBase : FunctionMessage
    {

    }

    public partial class VersionAPIFunction : VersionAPIFunctionBase { }

    [Function("versionAPI", "bytes32")]
    public class VersionAPIFunctionBase : FunctionMessage
    {

    }

    public partial class CheckContentObjectRightsFunction : CheckContentObjectRightsFunctionBase { }

    [Function("checkContentObjectRights", "bool")]
    public class CheckContentObjectRightsFunctionBase : FunctionMessage
    {
        [Parameter("address", "obj", 1)]
        public virtual string Obj { get; set; }
        [Parameter("uint8", "access_type", 2)]
        public virtual byte AccessType { get; set; }
    }

    public partial class CategoryContractFunction : CategoryContractFunctionBase { }

    [Function("CATEGORY_CONTRACT", "uint8")]
    public class CategoryContractFunctionBase : FunctionMessage
    {

    }

    public partial class CheckLibraryRightsFunction : CheckLibraryRightsFunctionBase { }

    [Function("checkLibraryRights", "bool")]
    public class CheckLibraryRightsFunctionBase : FunctionMessage
    {
        [Parameter("address", "lib", 1)]
        public virtual string Lib { get; set; }
        [Parameter("uint8", "access_type", 2)]
        public virtual byte AccessType { get; set; }
    }

    public partial class CategoryContentTypeFunction : CategoryContentTypeFunctionBase { }

    [Function("CATEGORY_CONTENT_TYPE", "uint8")]
    public class CategoryContentTypeFunctionBase : FunctionMessage
    {

    }

    public partial class GetContentObjectRightsFunction : GetContentObjectRightsFunctionBase { }

    [Function("getContentObjectRights", "uint8")]
    public class GetContentObjectRightsFunctionBase : FunctionMessage
    {
        [Parameter("address", "obj", 1)]
        public virtual string Obj { get; set; }
    }

    public partial class ContractsFunction : ContractsFunctionBase { }

    [Function("contracts", typeof(ContractsOutputDTO))]
    public class ContractsFunctionBase : FunctionMessage
    {

    }

    public partial class TransferCreatorshipFunction : TransferCreatorshipFunctionBase { }

    [Function("transferCreatorship")]
    public class TransferCreatorshipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newCreator", 1)]
        public virtual string NewCreator { get; set; }
    }

    public partial class GetContractFunction : GetContractFunctionBase { }

    [Function("getContract", "address")]
    public class GetContractFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "position", 1)]
        public virtual BigInteger Position { get; set; }
    }

    public partial class ContractExistsFunction : ContractExistsFunctionBase { }

    [Function("contractExists", "bool")]
    public class ContractExistsFunctionBase : FunctionMessage
    {
        [Parameter("address", "addr", 1)]
        public virtual string Addr { get; set; }
    }

    public partial class SetLibraryRightsFunction : SetLibraryRightsFunctionBase { }

    [Function("setLibraryRights")]
    public class SetLibraryRightsFunctionBase : FunctionMessage
    {
        [Parameter("address", "lib", 1)]
        public virtual string Lib { get; set; }
        [Parameter("uint8", "access_type", 2)]
        public virtual byte AccessType { get; set; }
        [Parameter("uint8", "access", 3)]
        public virtual byte Access { get; set; }
    }

    public partial class CheckRightsFunction : CheckRightsFunctionBase { }

    [Function("checkRights", "bool")]
    public class CheckRightsFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "index_type", 1)]
        public virtual byte IndexType { get; set; }
        [Parameter("address", "obj", 2)]
        public virtual string Obj { get; set; }
        [Parameter("uint8", "access_type", 3)]
        public virtual byte AccessType { get; set; }
    }

    public partial class AccessNoneFunction : AccessNoneFunctionBase { }

    [Function("ACCESS_NONE", "uint8")]
    public class AccessNoneFunctionBase : FunctionMessage
    {

    }

    public partial class CleanUpContentTypesFunction : CleanUpContentTypesFunctionBase { }

    [Function("cleanUpContentTypes", "uint256")]
    public class CleanUpContentTypesFunctionBase : FunctionMessage
    {

    }

    public partial class SetContentTypeRightsFunction : SetContentTypeRightsFunctionBase { }

    [Function("setContentTypeRights")]
    public class SetContentTypeRightsFunctionBase : FunctionMessage
    {
        [Parameter("address", "obj", 1)]
        public virtual string Obj { get; set; }
        [Parameter("uint8", "access_type", 2)]
        public virtual byte AccessType { get; set; }
        [Parameter("uint8", "access", 3)]
        public virtual byte Access { get; set; }
    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class CleanUpLibrariesFunction : CleanUpLibrariesFunctionBase { }

    [Function("cleanUpLibraries", "uint256")]
    public class CleanUpLibrariesFunctionBase : FunctionMessage
    {

    }

    public partial class TypeSeeFunction : TypeSeeFunctionBase { }

    [Function("TYPE_SEE", "uint8")]
    public class TypeSeeFunctionBase : FunctionMessage
    {

    }

    public partial class ContentTypesFunction : ContentTypesFunctionBase { }

    [Function("contentTypes", typeof(ContentTypesOutputDTO))]
    public class ContentTypesFunctionBase : FunctionMessage
    {

    }

    public partial class CheckDirectRightsFunction : CheckDirectRightsFunctionBase { }

    [Function("checkDirectRights", "bool")]
    public class CheckDirectRightsFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "index_type", 1)]
        public virtual byte IndexType { get; set; }
        [Parameter("address", "obj", 2)]
        public virtual string Obj { get; set; }
        [Parameter("uint8", "access_type", 3)]
        public virtual byte AccessType { get; set; }
    }

    public partial class GetContentTypeRightsFunction : GetContentTypeRightsFunctionBase { }

    [Function("getContentTypeRights", "uint8")]
    public class GetContentTypeRightsFunctionBase : FunctionMessage
    {
        [Parameter("address", "obj", 1)]
        public virtual string Obj { get; set; }
    }

    public partial class CheckContractRightsFunction : CheckContractRightsFunctionBase { }

    [Function("checkContractRights", "bool")]
    public class CheckContractRightsFunctionBase : FunctionMessage
    {
        [Parameter("address", "obj", 1)]
        public virtual string Obj { get; set; }
        [Parameter("uint8", "access_type", 2)]
        public virtual byte AccessType { get; set; }
    }

    public partial class ContentObjectsFunction : ContentObjectsFunctionBase { }

    [Function("contentObjects", typeof(ContentObjectsOutputDTO))]
    public class ContentObjectsFunctionBase : FunctionMessage
    {

    }

    public partial class GetContentTypeFunction : GetContentTypeFunctionBase { }

    [Function("getContentType", "address")]
    public class GetContentTypeFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "position", 1)]
        public virtual BigInteger Position { get; set; }
    }

    public partial class ContentSpaceFunction : ContentSpaceFunctionBase { }

    [Function("contentSpace", "address")]
    public class ContentSpaceFunctionBase : FunctionMessage
    {

    }

    public partial class SetAccessRightsFunction : SetAccessRightsFunctionBase { }

    [Function("setAccessRights")]
    public class SetAccessRightsFunctionBase : FunctionMessage
    {

    }

    public partial class LibrariesFunction : LibrariesFunctionBase { }

    [Function("libraries", typeof(LibrariesOutputDTO))]
    public class LibrariesFunctionBase : FunctionMessage
    {

    }

    public partial class GetLibrariesLengthFunction : GetLibrariesLengthFunctionBase { }

    [Function("getLibrariesLength", "uint256")]
    public class GetLibrariesLengthFunctionBase : FunctionMessage
    {

    }

    public partial class GetContentObjectFunction : GetContentObjectFunctionBase { }

    [Function("getContentObject", "address")]
    public class GetContentObjectFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "position", 1)]
        public virtual BigInteger Position { get; set; }
    }

    public partial class GetLibraryFunction : GetLibraryFunctionBase { }

    [Function("getLibrary", "address")]
    public class GetLibraryFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "position", 1)]
        public virtual BigInteger Position { get; set; }
    }

    public partial class TypeAccessFunction : TypeAccessFunctionBase { }

    [Function("TYPE_ACCESS", "uint8")]
    public class TypeAccessFunctionBase : FunctionMessage
    {

    }

    public partial class CleanUpAccessGroupsFunction : CleanUpAccessGroupsFunctionBase { }

    [Function("cleanUpAccessGroups", "uint256")]
    public class CleanUpAccessGroupsFunctionBase : FunctionMessage
    {

    }

    public partial class GetContentObjectsLengthFunction : GetContentObjectsLengthFunctionBase { }

    [Function("getContentObjectsLength", "uint256")]
    public class GetContentObjectsLengthFunctionBase : FunctionMessage
    {

    }

    public partial class SetAccessGroupRightsFunction : SetAccessGroupRightsFunctionBase { }

    [Function("setAccessGroupRights")]
    public class SetAccessGroupRightsFunctionBase : FunctionMessage
    {
        [Parameter("address", "group", 1)]
        public virtual string Group { get; set; }
        [Parameter("uint8", "access_type", 2)]
        public virtual byte AccessType { get; set; }
        [Parameter("uint8", "access", 3)]
        public virtual byte Access { get; set; }
    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class GetLibraryRightsFunction : GetLibraryRightsFunctionBase { }

    [Function("getLibraryRights", "uint8")]
    public class GetLibraryRightsFunctionBase : FunctionMessage
    {
        [Parameter("address", "lib", 1)]
        public virtual string Lib { get; set; }
    }

    public partial class GetContractsLengthFunction : GetContractsLengthFunctionBase { }

    [Function("getContractsLength", "uint256")]
    public class GetContractsLengthFunctionBase : FunctionMessage
    {

    }

    public partial class CheckContentTypeRightsFunction : CheckContentTypeRightsFunctionBase { }

    [Function("checkContentTypeRights", "bool")]
    public class CheckContentTypeRightsFunctionBase : FunctionMessage
    {
        [Parameter("address", "obj", 1)]
        public virtual string Obj { get; set; }
        [Parameter("uint8", "access_type", 2)]
        public virtual byte AccessType { get; set; }
    }

    public partial class RightsChangedEventDTO : RightsChangedEventDTOBase { }

    [Event("RightsChanged")]
    public class RightsChangedEventDTOBase : IEventDTO
    {
        [Parameter("address", "principal", 1, false )]
        public virtual string Principal { get; set; }
        [Parameter("address", "entity", 2, false )]
        public virtual string Entity { get; set; }
        [Parameter("uint8", "aggregate", 3, false )]
        public virtual byte Aggregate { get; set; }
    }

    public partial class CreatorOutputDTO : CreatorOutputDTOBase { }

    [FunctionOutput]
    public class CreatorOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }





    public partial class GetContractRightsOutputDTO : GetContractRightsOutputDTOBase { }

    [FunctionOutput]
    public class GetContractRightsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class CategoryContentObjectOutputDTO : CategoryContentObjectOutputDTOBase { }

    [FunctionOutput]
    public class CategoryContentObjectOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class GetAccessGroupsLengthOutputDTO : GetAccessGroupsLengthOutputDTOBase { }

    [FunctionOutput]
    public class GetAccessGroupsLengthOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CategoryGroupOutputDTO : CategoryGroupOutputDTOBase { }

    [FunctionOutput]
    public class CategoryGroupOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class CheckAccessGroupRightsOutputDTO : CheckAccessGroupRightsOutputDTOBase { }

    [FunctionOutput]
    public class CheckAccessGroupRightsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class CategoryLibraryOutputDTO : CategoryLibraryOutputDTOBase { }

    [FunctionOutput]
    public class CategoryLibraryOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class AccessConfirmedOutputDTO : AccessConfirmedOutputDTOBase { }

    [FunctionOutput]
    public class AccessConfirmedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }



    public partial class GetAccessGroupOutputDTO : GetAccessGroupOutputDTOBase { }

    [FunctionOutput]
    public class GetAccessGroupOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class CleanUpAllOutputDTO : CleanUpAllOutputDTOBase { }

    [FunctionOutput]
    public class CleanUpAllOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
        [Parameter("uint256", "", 2)]
        public virtual BigInteger ReturnValue2 { get; set; }
        [Parameter("uint256", "", 3)]
        public virtual BigInteger ReturnValue3 { get; set; }
        [Parameter("uint256", "", 4)]
        public virtual BigInteger ReturnValue4 { get; set; }
        [Parameter("uint256", "", 5)]
        public virtual BigInteger ReturnValue5 { get; set; }
    }

    public partial class GetAccessGroupRightsOutputDTO : GetAccessGroupRightsOutputDTOBase { }

    [FunctionOutput]
    public class GetAccessGroupRightsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class AccessGroupsOutputDTO : AccessGroupsOutputDTOBase { }

    [FunctionOutput]
    public class AccessGroupsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "category", 1)]
        public virtual byte Category { get; set; }
        [Parameter("uint256", "length", 2)]
        public virtual BigInteger Length { get; set; }
    }





    public partial class HasManagerAccessOutputDTO : HasManagerAccessOutputDTOBase { }

    [FunctionOutput]
    public class HasManagerAccessOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class AccessTentativeOutputDTO : AccessTentativeOutputDTOBase { }

    [FunctionOutput]
    public class AccessTentativeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class OthersOutputDTO : OthersOutputDTOBase { }

    [FunctionOutput]
    public class OthersOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "category", 1)]
        public virtual byte Category { get; set; }
        [Parameter("uint256", "length", 2)]
        public virtual BigInteger Length { get; set; }
    }

    public partial class VersionOutputDTO : VersionOutputDTOBase { }

    [FunctionOutput]
    public class VersionOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class GetContentTypesLengthOutputDTO : GetContentTypesLengthOutputDTOBase { }

    [FunctionOutput]
    public class GetContentTypesLengthOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class TypeEditOutputDTO : TypeEditOutputDTOBase { }

    [FunctionOutput]
    public class TypeEditOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class VersionAPIOutputDTO : VersionAPIOutputDTOBase { }

    [FunctionOutput]
    public class VersionAPIOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class CheckContentObjectRightsOutputDTO : CheckContentObjectRightsOutputDTOBase { }

    [FunctionOutput]
    public class CheckContentObjectRightsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class CategoryContractOutputDTO : CategoryContractOutputDTOBase { }

    [FunctionOutput]
    public class CategoryContractOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class CheckLibraryRightsOutputDTO : CheckLibraryRightsOutputDTOBase { }

    [FunctionOutput]
    public class CheckLibraryRightsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class CategoryContentTypeOutputDTO : CategoryContentTypeOutputDTOBase { }

    [FunctionOutput]
    public class CategoryContentTypeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class GetContentObjectRightsOutputDTO : GetContentObjectRightsOutputDTOBase { }

    [FunctionOutput]
    public class GetContentObjectRightsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class ContractsOutputDTO : ContractsOutputDTOBase { }

    [FunctionOutput]
    public class ContractsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "category", 1)]
        public virtual byte Category { get; set; }
        [Parameter("uint256", "length", 2)]
        public virtual BigInteger Length { get; set; }
    }



    public partial class GetContractOutputDTO : GetContractOutputDTOBase { }

    [FunctionOutput]
    public class GetContractOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class ContractExistsOutputDTO : ContractExistsOutputDTOBase { }

    [FunctionOutput]
    public class ContractExistsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }



    public partial class CheckRightsOutputDTO : CheckRightsOutputDTOBase { }

    [FunctionOutput]
    public class CheckRightsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class AccessNoneOutputDTO : AccessNoneOutputDTOBase { }

    [FunctionOutput]
    public class AccessNoneOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }





    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class TypeSeeOutputDTO : TypeSeeOutputDTOBase { }

    [FunctionOutput]
    public class TypeSeeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class ContentTypesOutputDTO : ContentTypesOutputDTOBase { }

    [FunctionOutput]
    public class ContentTypesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "category", 1)]
        public virtual byte Category { get; set; }
        [Parameter("uint256", "length", 2)]
        public virtual BigInteger Length { get; set; }
    }

    public partial class CheckDirectRightsOutputDTO : CheckDirectRightsOutputDTOBase { }

    [FunctionOutput]
    public class CheckDirectRightsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class GetContentTypeRightsOutputDTO : GetContentTypeRightsOutputDTOBase { }

    [FunctionOutput]
    public class GetContentTypeRightsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class CheckContractRightsOutputDTO : CheckContractRightsOutputDTOBase { }

    [FunctionOutput]
    public class CheckContractRightsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class ContentObjectsOutputDTO : ContentObjectsOutputDTOBase { }

    [FunctionOutput]
    public class ContentObjectsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "category", 1)]
        public virtual byte Category { get; set; }
        [Parameter("uint256", "length", 2)]
        public virtual BigInteger Length { get; set; }
    }

    public partial class GetContentTypeOutputDTO : GetContentTypeOutputDTOBase { }

    [FunctionOutput]
    public class GetContentTypeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class ContentSpaceOutputDTO : ContentSpaceOutputDTOBase { }

    [FunctionOutput]
    public class ContentSpaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class LibrariesOutputDTO : LibrariesOutputDTOBase { }

    [FunctionOutput]
    public class LibrariesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "category", 1)]
        public virtual byte Category { get; set; }
        [Parameter("uint256", "length", 2)]
        public virtual BigInteger Length { get; set; }
    }

    public partial class GetLibrariesLengthOutputDTO : GetLibrariesLengthOutputDTOBase { }

    [FunctionOutput]
    public class GetLibrariesLengthOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetContentObjectOutputDTO : GetContentObjectOutputDTOBase { }

    [FunctionOutput]
    public class GetContentObjectOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetLibraryOutputDTO : GetLibraryOutputDTOBase { }

    [FunctionOutput]
    public class GetLibraryOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TypeAccessOutputDTO : TypeAccessOutputDTOBase { }

    [FunctionOutput]
    public class TypeAccessOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }



    public partial class GetContentObjectsLengthOutputDTO : GetContentObjectsLengthOutputDTOBase { }

    [FunctionOutput]
    public class GetContentObjectsLengthOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }





    public partial class GetLibraryRightsOutputDTO : GetLibraryRightsOutputDTOBase { }

    [FunctionOutput]
    public class GetLibraryRightsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class GetContractsLengthOutputDTO : GetContractsLengthOutputDTOBase { }

    [FunctionOutput]
    public class GetContractsLengthOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CheckContentTypeRightsOutputDTO : CheckContentTypeRightsOutputDTOBase { }

    [FunctionOutput]
    public class CheckContentTypeRightsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }
}
