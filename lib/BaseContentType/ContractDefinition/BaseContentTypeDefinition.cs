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

namespace Elv.NET.Contracts.BaseContentType.ContractDefinition
{


    public partial class BaseContentTypeDeployment : BaseContentTypeDeploymentBase
    {
        public BaseContentTypeDeployment() : base(BYTECODE) { }
        public BaseContentTypeDeployment(string byteCode) : base(byteCode) { }
    }

    public class BaseContentTypeDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public BaseContentTypeDeploymentBase() : base(BYTECODE) { }
        public BaseContentTypeDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "content_space", 1)]
        public virtual string ContentSpace { get; set; }
    }

    public partial class ParentAddressFunction : ParentAddressFunctionBase { }

    [Function("parentAddress", "address")]
    public class ParentAddressFunctionBase : FunctionMessage
    {

    }

    public partial class CreatorFunction : CreatorFunctionBase { }

    [Function("creator", "address")]
    public class CreatorFunctionBase : FunctionMessage
    {

    }

    public partial class SetRightsFunction : SetRightsFunctionBase { }

    [Function("setRights")]
    public class SetRightsFunctionBase : FunctionMessage
    {
        [Parameter("address", "stakeholder", 1)]
        public virtual string Stakeholder { get; set; }
        [Parameter("uint8", "access_type", 2)]
        public virtual byte AccessType { get; set; }
        [Parameter("uint8", "access", 3)]
        public virtual byte Access { get; set; }
    }

    public partial class CanSeeFunction : CanSeeFunctionBase { }

    [Function("CAN_SEE", "uint8")]
    public class CanSeeFunctionBase : FunctionMessage
    {

    }

    public partial class CanConfirmFunction : CanConfirmFunctionBase { }

    [Function("canConfirm", "bool")]
    public class CanConfirmFunctionBase : FunctionMessage
    {

    }

    public partial class AccessRequestV3Function : AccessRequestV3FunctionBase { }

    [Function("accessRequestV3", "bool")]
    public class AccessRequestV3FunctionBase : FunctionMessage
    {
        [Parameter("bytes32[]", "", 1)]
        public virtual List<byte[]> ReturnValue1 { get; set; }
        [Parameter("address[]", "", 2)]
        public virtual List<string> ReturnValue2 { get; set; }
    }

    public partial class SetGroupRightsFunction : SetGroupRightsFunctionBase { }

    [Function("setGroupRights")]
    public class SetGroupRightsFunctionBase : FunctionMessage
    {
        [Parameter("address", "group", 1)]
        public virtual string Group { get; set; }
        [Parameter("uint8", "access_type", 2)]
        public virtual byte AccessType { get; set; }
        [Parameter("uint8", "access", 3)]
        public virtual byte Access { get; set; }
    }

    public partial class VisibilityFunction : VisibilityFunctionBase { }

    [Function("visibility", "uint8")]
    public class VisibilityFunctionBase : FunctionMessage
    {

    }

    public partial class CountVersionHashesFunction : CountVersionHashesFunctionBase { }

    [Function("countVersionHashes", "uint256")]
    public class CountVersionHashesFunctionBase : FunctionMessage
    {

    }

    public partial class CommitPendingFunction : CommitPendingFunctionBase { }

    [Function("commitPending", "bool")]
    public class CommitPendingFunctionBase : FunctionMessage
    {

    }

    public partial class ObjectTimestampFunction : ObjectTimestampFunctionBase { }

    [Function("objectTimestamp", "uint256")]
    public class ObjectTimestampFunctionBase : FunctionMessage
    {

    }

    public partial class KillFunction : KillFunctionBase { }

    [Function("kill")]
    public class KillFunctionBase : FunctionMessage
    {

    }

    public partial class ConfirmCommitFunction : ConfirmCommitFunctionBase { }

    [Function("confirmCommit", "bool")]
    public class ConfirmCommitFunctionBase : FunctionMessage
    {

    }

    public partial class VersionFunction : VersionFunctionBase { }

    [Function("version", "bytes32")]
    public class VersionFunctionBase : FunctionMessage
    {

    }

    public partial class VersionAPIFunction : VersionAPIFunctionBase { }

    [Function("versionAPI", "bytes32")]
    public class VersionAPIFunctionBase : FunctionMessage
    {

    }

    public partial class ClearPendingFunction : ClearPendingFunctionBase { }

    [Function("clearPending")]
    public class ClearPendingFunctionBase : FunctionMessage
    {

    }

    public partial class PendingHashFunction : PendingHashFunctionBase { }

    [Function("pendingHash", "string")]
    public class PendingHashFunctionBase : FunctionMessage
    {

    }

    public partial class IndexCategoryFunction : IndexCategoryFunctionBase { }

    [Function("indexCategory", "uint8")]
    public class IndexCategoryFunctionBase : FunctionMessage
    {

    }

    public partial class HasEditorRightFunction : HasEditorRightFunctionBase { }

    [Function("hasEditorRight", "bool")]
    public class HasEditorRightFunctionBase : FunctionMessage
    {
        [Parameter("address", "candidate", 1)]
        public virtual string Candidate { get; set; }
    }

    public partial class TransferCreatorshipFunction : TransferCreatorshipFunctionBase { }

    [Function("transferCreatorship")]
    public class TransferCreatorshipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newCreator", 1)]
        public virtual string NewCreator { get; set; }
    }

    public partial class CanCommitFunction : CanCommitFunctionBase { }

    [Function("canCommit", "bool")]
    public class CanCommitFunctionBase : FunctionMessage
    {

    }

    public partial class VersionTimestampFunction : VersionTimestampFunctionBase { }

    [Function("versionTimestamp", "uint256")]
    public class VersionTimestampFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class VersionHashesFunction : VersionHashesFunctionBase { }

    [Function("versionHashes", "string")]
    public class VersionHashesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CanEditFunction : CanEditFunctionBase { }

    [Function("canEdit", "bool")]
    public class CanEditFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class HasAccessFunction : HasAccessFunctionBase { }

    [Function("hasAccess", "bool")]
    public class HasAccessFunctionBase : FunctionMessage
    {
        [Parameter("address", "candidate", 1)]
        public virtual string Candidate { get; set; }
    }

    public partial class CanAccessFunction : CanAccessFunctionBase { }

    [Function("CAN_ACCESS", "uint8")]
    public class CanAccessFunctionBase : FunctionMessage
    {

    }

    public partial class CommitFunction : CommitFunctionBase { }

    [Function("commit")]
    public class CommitFunctionBase : FunctionMessage
    {
        [Parameter("string", "_objectHash", 1)]
        public virtual string ObjectHash { get; set; }
    }

    public partial class SetVisibilityFunction : SetVisibilityFunctionBase { }

    [Function("setVisibility")]
    public class SetVisibilityFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "_visibility_code", 1)]
        public virtual byte VisibilityCode { get; set; }
    }

    public partial class ContentSpaceFunction : ContentSpaceFunctionBase { }

    [Function("contentSpace", "address")]
    public class ContentSpaceFunctionBase : FunctionMessage
    {

    }

    public partial class UpdateRequestFunction : UpdateRequestFunctionBase { }

    [Function("updateRequest")]
    public class UpdateRequestFunctionBase : FunctionMessage
    {

    }

    public partial class ObjectHashFunction : ObjectHashFunctionBase { }

    [Function("objectHash", "string")]
    public class ObjectHashFunctionBase : FunctionMessage
    {

    }

    public partial class DeleteVersionFunction : DeleteVersionFunctionBase { }

    [Function("deleteVersion", "int256")]
    public class DeleteVersionFunctionBase : FunctionMessage
    {
        [Parameter("string", "_versionHash", 1)]
        public virtual string VersionHash { get; set; }
    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class CommitPendingEventDTO : CommitPendingEventDTOBase { }

    [Event("CommitPending")]
    public class CommitPendingEventDTOBase : IEventDTO
    {
        [Parameter("address", "spaceAddress", 1, false)]
        public virtual string SpaceAddress { get; set; }
        [Parameter("address", "parentAddress", 2, false)]
        public virtual string ParentAddress { get; set; }
        [Parameter("string", "objectHash", 3, false)]
        public virtual string ObjectHash { get; set; }
    }

    public partial class UpdateRequestEventDTO : UpdateRequestEventDTOBase { }

    [Event("UpdateRequest")]
    public class UpdateRequestEventDTOBase : IEventDTO
    {
        [Parameter("string", "objectHash", 1, false)]
        public virtual string ObjectHash { get; set; }
    }

    public partial class VersionConfirmEventDTO : VersionConfirmEventDTOBase { }

    [Event("VersionConfirm")]
    public class VersionConfirmEventDTOBase : IEventDTO
    {
        [Parameter("address", "spaceAddress", 1, false)]
        public virtual string SpaceAddress { get; set; }
        [Parameter("address", "parentAddress", 2, false)]
        public virtual string ParentAddress { get; set; }
        [Parameter("string", "objectHash", 3, false)]
        public virtual string ObjectHash { get; set; }
    }

    public partial class VersionDeleteEventDTO : VersionDeleteEventDTOBase { }

    [Event("VersionDelete")]
    public class VersionDeleteEventDTOBase : IEventDTO
    {
        [Parameter("address", "spaceAddress", 1, false)]
        public virtual string SpaceAddress { get; set; }
        [Parameter("string", "versionHash", 2, false)]
        public virtual string VersionHash { get; set; }
        [Parameter("int256", "index", 3, false)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class AccessRequestV3EventDTO : AccessRequestV3EventDTOBase { }

    [Event("AccessRequestV3")]
    public class AccessRequestV3EventDTOBase : IEventDTO
    {
        [Parameter("uint256", "requestNonce", 1, false)]
        public virtual BigInteger RequestNonce { get; set; }
        [Parameter("address", "parentAddress", 2, false)]
        public virtual string ParentAddress { get; set; }
        [Parameter("bytes32", "contextHash", 3, false)]
        public virtual byte[] ContextHash { get; set; }
        [Parameter("address", "accessor", 4, false)]
        public virtual string Accessor { get; set; }
        [Parameter("uint256", "requestTimestamp", 5, false)]
        public virtual BigInteger RequestTimestamp { get; set; }
    }

    public partial class VisibilityChangedEventDTO : VisibilityChangedEventDTOBase { }

    [Event("VisibilityChanged")]
    public class VisibilityChangedEventDTOBase : IEventDTO
    {
        [Parameter("address", "contentSpace", 1, false)]
        public virtual string ContentSpace { get; set; }
        [Parameter("address", "parentAddress", 2, false)]
        public virtual string ParentAddress { get; set; }
        [Parameter("uint8", "visibility", 3, false)]
        public virtual byte Visibility { get; set; }
    }

    public partial class ParentAddressOutputDTO : ParentAddressOutputDTOBase { }

    [FunctionOutput]
    public class ParentAddressOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class CreatorOutputDTO : CreatorOutputDTOBase { }

    [FunctionOutput]
    public class CreatorOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class CanSeeOutputDTO : CanSeeOutputDTOBase { }

    [FunctionOutput]
    public class CanSeeOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class CanConfirmOutputDTO : CanConfirmOutputDTOBase { }

    [FunctionOutput]
    public class CanConfirmOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }





    public partial class VisibilityOutputDTO : VisibilityOutputDTOBase { }

    [FunctionOutput]
    public class VisibilityOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class CountVersionHashesOutputDTO : CountVersionHashesOutputDTOBase { }

    [FunctionOutput]
    public class CountVersionHashesOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CommitPendingOutputDTO : CommitPendingOutputDTOBase { }

    [FunctionOutput]
    public class CommitPendingOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class ObjectTimestampOutputDTO : ObjectTimestampOutputDTOBase { }

    [FunctionOutput]
    public class ObjectTimestampOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }





    public partial class VersionOutputDTO : VersionOutputDTOBase { }

    [FunctionOutput]
    public class VersionOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class VersionAPIOutputDTO : VersionAPIOutputDTOBase { }

    [FunctionOutput]
    public class VersionAPIOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }



    public partial class PendingHashOutputDTO : PendingHashOutputDTOBase { }

    [FunctionOutput]
    public class PendingHashOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class IndexCategoryOutputDTO : IndexCategoryOutputDTOBase { }

    [FunctionOutput]
    public class IndexCategoryOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class HasEditorRightOutputDTO : HasEditorRightOutputDTOBase { }

    [FunctionOutput]
    public class HasEditorRightOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }



    public partial class CanCommitOutputDTO : CanCommitOutputDTOBase { }

    [FunctionOutput]
    public class CanCommitOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class VersionTimestampOutputDTO : VersionTimestampOutputDTOBase { }

    [FunctionOutput]
    public class VersionTimestampOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class VersionHashesOutputDTO : VersionHashesOutputDTOBase { }

    [FunctionOutput]
    public class VersionHashesOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class CanEditOutputDTO : CanEditOutputDTOBase { }

    [FunctionOutput]
    public class CanEditOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class HasAccessOutputDTO : HasAccessOutputDTOBase { }

    [FunctionOutput]
    public class HasAccessOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class CanAccessOutputDTO : CanAccessOutputDTOBase { }

    [FunctionOutput]
    public class CanAccessOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }





    public partial class ContentSpaceOutputDTO : ContentSpaceOutputDTOBase { }

    [FunctionOutput]
    public class ContentSpaceOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class ObjectHashOutputDTO : ObjectHashOutputDTOBase { }

    [FunctionOutput]
    public class ObjectHashOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }


}
