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

namespace NethereumSample.BaseContent.ContractDefinition
{


    public partial class BaseContentDeployment : BaseContentDeploymentBase
    {
        public BaseContentDeployment() : base(BYTECODE) { }
        public BaseContentDeployment(string byteCode) : base(byteCode) { }
    }

    public class BaseContentDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public BaseContentDeploymentBase() : base(BYTECODE) { }
        public BaseContentDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "content_space", 1)]
        public virtual string ContentSpace { get; set; }
        [Parameter("address", "lib", 2)]
        public virtual string Lib { get; set; }
        [Parameter("address", "content_type", 3)]
        public virtual string ContentType { get; set; }
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

    public partial class AccessCompleteFunction : AccessCompleteFunctionBase { }

    [Function("accessComplete", "bool")]
    public class AccessCompleteFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "request_ID", 1)]
        public virtual BigInteger RequestId { get; set; }
        [Parameter("uint256", "score_pct", 2)]
        public virtual BigInteger ScorePct { get; set; }
        [Parameter("uint256", "", 3)]
        public virtual BigInteger ReturnValue3 { get; set; }
    }

    public partial class PublishFunction : PublishFunctionBase { }

    [Function("publish", "bool")]
    public class PublishFunctionBase : FunctionMessage
    {

    }

    public partial class ProcessRequestPaymentFunction : ProcessRequestPaymentFunctionBase { }

    [Function("processRequestPayment", "bool")]
    public class ProcessRequestPaymentFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "requestNonce", 1)]
        public virtual BigInteger RequestNonce { get; set; }
        [Parameter("address", "payee", 2)]
        public virtual string Payee { get; set; }
        [Parameter("string", "label", 3)]
        public virtual string Label { get; set; }
        [Parameter("uint256", "amount", 4)]
        public virtual BigInteger Amount { get; set; }
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

    public partial class RequestMapFunction : RequestMapFunctionBase { }

    [Function("requestMap", typeof(RequestMapOutputDTO))]
    public class RequestMapFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class AccessRequestV3Function : AccessRequestV3FunctionBase { }

    [Function("accessRequestV3", "bool")]
    public class AccessRequestV3FunctionBase : FunctionMessage
    {
        [Parameter("bytes32[]", "customValues", 1)]
        public virtual List<byte[]> CustomValues { get; set; }
        [Parameter("address[]", "stakeholders", 2)]
        public virtual List<string> Stakeholders { get; set; }
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

    public partial class ContentContractAddressFunction : ContentContractAddressFunctionBase { }

    [Function("contentContractAddress", "address")]
    public class ContentContractAddressFunctionBase : FunctionMessage
    {

    }

    public partial class IsAdminFunction : IsAdminFunctionBase { }

    [Function("isAdmin", "bool")]
    public class IsAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "_candidate", 1)]
        public virtual string Candidate { get; set; }
    }

    public partial class StatusCodeFunction : StatusCodeFunctionBase { }

    [Function("statusCode", "int256")]
    public class StatusCodeFunctionBase : FunctionMessage
    {

    }

    public partial class VisibilityFunction : VisibilityFunctionBase { }

    [Function("visibility", "uint8")]
    public class VisibilityFunctionBase : FunctionMessage
    {

    }

    public partial class AddressKMSFunction : AddressKMSFunctionBase { }

    [Function("addressKMS", "address")]
    public class AddressKMSFunctionBase : FunctionMessage
    {

    }

    public partial class CountVersionHashesFunction : CountVersionHashesFunctionBase { }

    [Function("countVersionHashes", "uint256")]
    public class CountVersionHashesFunctionBase : FunctionMessage
    {

    }

    public partial class ContentTypeFunction : ContentTypeFunctionBase { }

    [Function("contentType", "address")]
    public class ContentTypeFunctionBase : FunctionMessage
    {

    }

    public partial class CommitPendingFunction : CommitPendingFunctionBase { }

    [Function("commitPending", "bool")]
    public class CommitPendingFunctionBase : FunctionMessage
    {

    }

    public partial class GetAccessInfoFunction : GetAccessInfoFunctionBase { }

    [Function("getAccessInfo", typeof(GetAccessInfoOutputDTO))]
    public class GetAccessInfoFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
        [Parameter("bytes32[]", "customValues", 2)]
        public virtual List<byte[]> CustomValues { get; set; }
        [Parameter("address[]", "stakeholders", 3)]
        public virtual List<string> Stakeholders { get; set; }
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

    public partial class AccessCompleteV3Function : AccessCompleteV3FunctionBase { }

    [Function("accessCompleteV3", "bool")]
    public class AccessCompleteV3FunctionBase : FunctionMessage
    {
        [Parameter("uint256", "requestNonce", 1)]
        public virtual BigInteger RequestNonce { get; set; }
        [Parameter("bytes32[]", "customValues", 2)]
        public virtual List<byte[]> CustomValues { get; set; }
        [Parameter("address[]", "stakeholders", 3)]
        public virtual List<string> Stakeholders { get; set; }
    }

    public partial class AccessCompleteInternalFunction : AccessCompleteInternalFunctionBase { }

    [Function("accessCompleteInternal", "bool")]
    public class AccessCompleteInternalFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "requestNonce", 1)]
        public virtual BigInteger RequestNonce { get; set; }
        [Parameter("bytes32[]", "customValues", 2)]
        public virtual List<byte[]> CustomValues { get; set; }
        [Parameter("address[]", "stakeholders", 3)]
        public virtual List<string> Stakeholders { get; set; }
    }

    public partial class SetStatusCodeFunction : SetStatusCodeFunctionBase { }

    [Function("setStatusCode", "int256")]
    public class SetStatusCodeFunctionBase : FunctionMessage
    {
        [Parameter("int256", "status_code", 1)]
        public virtual BigInteger StatusCode { get; set; }
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

    public partial class AccessChargeFunction : AccessChargeFunctionBase { }

    [Function("accessCharge", "uint256")]
    public class AccessChargeFunctionBase : FunctionMessage
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

    public partial class AccessRequestContextFunction : AccessRequestContextFunctionBase { }

    [Function("accessRequestContext", "uint256")]
    public class AccessRequestContextFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "requestNonce", 1)]
        public virtual BigInteger RequestNonce { get; set; }
        [Parameter("bytes32", "contextHash", 2)]
        public virtual byte[] ContextHash { get; set; }
        [Parameter("address", "accessor", 3)]
        public virtual string Accessor { get; set; }
        [Parameter("uint256", "request_timestamp", 4)]
        public virtual BigInteger RequestTimestamp { get; set; }
    }

    public partial class VersionHashesFunction : VersionHashesFunctionBase { }

    [Function("versionHashes", "string")]
    public class VersionHashesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetAccessInfoV3Function : GetAccessInfoV3FunctionBase { }

    [Function("getAccessInfoV3", typeof(GetAccessInfoV3OutputDTO))]
    public class GetAccessInfoV3FunctionBase : FunctionMessage
    {
        [Parameter("address", "accessor", 1)]
        public virtual string Accessor { get; set; }
        [Parameter("bytes32[]", "customValues", 2)]
        public virtual List<byte[]> CustomValues { get; set; }
        [Parameter("address[]", "stakeholders", 3)]
        public virtual List<string> Stakeholders { get; set; }
    }

    public partial class CanEditFunction : CanEditFunctionBase { }

    [Function("canEdit", "bool")]
    public class CanEditFunctionBase : FunctionMessage
    {

    }

    public partial class UpdateStatusFunction : UpdateStatusFunctionBase { }

    [Function("updateStatus", "int256")]
    public class UpdateStatusFunctionBase : FunctionMessage
    {
        [Parameter("int256", "status_code", 1)]
        public virtual BigInteger StatusCode { get; set; }
    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class RequestIDFunction : RequestIDFunctionBase { }

    [Function("requestID", "uint256")]
    public class RequestIDFunctionBase : FunctionMessage
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

    public partial class AccessRequestFunction : AccessRequestFunctionBase { }

    [Function("accessRequest", "uint256")]
    public class AccessRequestFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
        [Parameter("string", "pkeRequestor", 2)]
        public virtual string PkeRequestor { get; set; }
        [Parameter("string", "pkeAFGH", 3)]
        public virtual string PkeAFGH { get; set; }
        [Parameter("bytes32[]", "customValues", 4)]
        public virtual List<byte[]> CustomValues { get; set; }
        [Parameter("address[]", "stakeholders", 5)]
        public virtual List<string> Stakeholders { get; set; }
    }

    public partial class GetKMSInfoFunction : GetKMSInfoFunctionBase { }

    [Function("getKMSInfo", typeof(GetKMSInfoOutputDTO))]
    public class GetKMSInfoFunctionBase : FunctionMessage
    {
        [Parameter("bytes", "prefix", 1)]
        public virtual byte[] Prefix { get; set; }
    }

    public partial class SetVisibilityFunction : SetVisibilityFunctionBase { }

    [Function("setVisibility")]
    public class SetVisibilityFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "_visibility_code", 1)]
        public virtual byte VisibilityCode { get; set; }
    }

    public partial class GetMetaFunction : GetMetaFunctionBase { }

    [Function("getMeta", "bytes")]
    public class GetMetaFunctionBase : FunctionMessage
    {
        [Parameter("bytes", "key", 1)]
        public virtual byte[] Key { get; set; }
    }

    public partial class ContentSpaceFunction : ContentSpaceFunctionBase { }

    [Function("contentSpace", "address")]
    public class ContentSpaceFunctionBase : FunctionMessage
    {

    }

    public partial class LibraryAddressFunction : LibraryAddressFunctionBase { }

    [Function("libraryAddress", "address")]
    public class LibraryAddressFunctionBase : FunctionMessage
    {

    }

    public partial class AccessCompleteContextFunction : AccessCompleteContextFunctionBase { }

    [Function("accessCompleteContext", "bool")]
    public class AccessCompleteContextFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "_requestNonce", 1)]
        public virtual BigInteger RequestNonce { get; set; }
        [Parameter("bytes32", "_contextHash", 2)]
        public virtual byte[] ContextHash { get; set; }
        [Parameter("address", "_accessor", 3)]
        public virtual string Accessor { get; set; }
        [Parameter("uint256", "_request_timestamp", 4)]
        public virtual BigInteger RequestTimestamp { get; set; }
    }

    public partial class GetCustomInfoFunction : GetCustomInfoFunctionBase { }

    [Function("getCustomInfo", typeof(GetCustomInfoOutputDTO))]
    public class GetCustomInfoFunctionBase : FunctionMessage
    {
        [Parameter("address", "accessor", 1)]
        public virtual string Accessor { get; set; }
        [Parameter("bytes32[]", "customValues", 2)]
        public virtual List<byte[]> CustomValues { get; set; }
        [Parameter("address[]", "stakeholders", 3)]
        public virtual List<string> Stakeholders { get; set; }
    }

    public partial class UpdateRequestFunction : UpdateRequestFunctionBase { }

    [Function("updateRequest")]
    public class UpdateRequestFunctionBase : FunctionMessage
    {

    }

    public partial class SetAddressKMSFunction : SetAddressKMSFunctionBase { }

    [Function("setAddressKMS")]
    public class SetAddressKMSFunctionBase : FunctionMessage
    {
        [Parameter("address", "address_KMS", 1)]
        public virtual string AddressKms { get; set; }
    }

    public partial class CanPublishFunction : CanPublishFunctionBase { }

    [Function("canPublish", "bool")]
    public class CanPublishFunctionBase : FunctionMessage
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

    public partial class SetContentContractAddressFunction : SetContentContractAddressFunctionBase { }

    [Function("setContentContractAddress")]
    public class SetContentContractAddressFunctionBase : FunctionMessage
    {
        [Parameter("address", "addr", 1)]
        public virtual string Addr { get; set; }
    }

    public partial class PutMetaFunction : PutMetaFunctionBase { }

    [Function("putMeta")]
    public class PutMetaFunctionBase : FunctionMessage
    {
        [Parameter("bytes", "key", 1)]
        public virtual byte[] Key { get; set; }
        [Parameter("bytes", "value", 2)]
        public virtual byte[] Value { get; set; }
    }



    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class SetAccessChargeFunction : SetAccessChargeFunctionBase { }

    [Function("setAccessCharge", "uint256")]
    public class SetAccessChargeFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "charge", 1)]
        public virtual BigInteger Charge { get; set; }
    }

    public partial class ContentObjectCreateEventDTO : ContentObjectCreateEventDTOBase { }

    [Event("ContentObjectCreate")]
    public class ContentObjectCreateEventDTOBase : IEventDTO
    {
        [Parameter("address", "containingLibrary", 1, false)]
        public virtual string ContainingLibrary { get; set; }
    }

    public partial class SetContentTypeEventDTO : SetContentTypeEventDTOBase { }

    [Event("SetContentType")]
    public class SetContentTypeEventDTOBase : IEventDTO
    {
        [Parameter("address", "contentType", 1, false)]
        public virtual string ContentType { get; set; }
        [Parameter("address", "contentContractAddress", 2, false)]
        public virtual string ContentContractAddress { get; set; }
    }

    public partial class LogPaymentEventDTO : LogPaymentEventDTOBase { }

    [Event("LogPayment")]
    public class LogPaymentEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "requestNonce", 1, false)]
        public virtual BigInteger RequestNonce { get; set; }
        [Parameter("string", "label", 2, false)]
        public virtual string Label { get; set; }
        [Parameter("address", "payee", 3, false)]
        public virtual string Payee { get; set; }
        [Parameter("uint256", "amount", 4, false)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class AccessRequestValueEventDTO : AccessRequestValueEventDTOBase { }

    [Event("AccessRequestValue")]
    public class AccessRequestValueEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "customValue", 1, false)]
        public virtual byte[] CustomValue { get; set; }
    }

    public partial class AccessRequestStakeholderEventDTO : AccessRequestStakeholderEventDTOBase { }

    [Event("AccessRequestStakeholder")]
    public class AccessRequestStakeholderEventDTOBase : IEventDTO
    {
        [Parameter("address", "stakeholder", 1, false)]
        public virtual string Stakeholder { get; set; }
    }

    public partial class AccessRequestEventDTO : AccessRequestEventDTOBase { }

    [Event("AccessRequest")]
    public class AccessRequestEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "requestID", 1, false)]
        public virtual BigInteger RequestID { get; set; }
        [Parameter("uint8", "level", 2, false)]
        public virtual byte Level { get; set; }
        [Parameter("string", "contentHash", 3, false)]
        public virtual string ContentHash { get; set; }
        [Parameter("string", "pkeRequestor", 4, false)]
        public virtual string PkeRequestor { get; set; }
        [Parameter("string", "pkeAFGH", 5, false)]
        public virtual string PkeAFGH { get; set; }
    }

    public partial class AccessCompleteEventDTO : AccessCompleteEventDTOBase { }

    [Event("AccessComplete")]
    public class AccessCompleteEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "requestID", 1, false)]
        public virtual BigInteger RequestID { get; set; }
        [Parameter("uint256", "scorePct", 2, false)]
        public virtual BigInteger ScorePct { get; set; }
        [Parameter("bool", "customContractResult", 3, false)]
        public virtual bool CustomContractResult { get; set; }
    }

    public partial class AccessCompleteV3EventDTO : AccessCompleteV3EventDTOBase { }

    [Event("AccessCompleteV3")]
    public class AccessCompleteV3EventDTOBase : IEventDTO
    {
        [Parameter("uint256", "requestNonce", 1, false)]
        public virtual BigInteger RequestNonce { get; set; }
        [Parameter("bool", "customContractResult", 2, false)]
        public virtual bool CustomContractResult { get; set; }
        [Parameter("address", "parentAddress", 3, false)]
        public virtual string ParentAddress { get; set; }
        [Parameter("bytes32", "contextHash", 4, false)]
        public virtual byte[] ContextHash { get; set; }
        [Parameter("address", "accessor", 5, false)]
        public virtual string Accessor { get; set; }
        [Parameter("uint256", "request_timestamp", 6, false)]
        public virtual BigInteger RequestTimestamp { get; set; }
    }

    public partial class SetContentContractEventDTO : SetContentContractEventDTOBase { }

    [Event("SetContentContract")]
    public class SetContentContractEventDTOBase : IEventDTO
    {
        [Parameter("address", "contentContractAddress", 1, false)]
        public virtual string ContentContractAddress { get; set; }
    }

    public partial class SetAccessChargeEventDTO : SetAccessChargeEventDTOBase { }

    [Event("SetAccessCharge")]
    public class SetAccessChargeEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "accessCharge", 1, false)]
        public virtual BigInteger AccessCharge { get; set; }
    }

    public partial class InsufficientFundsEventDTO : InsufficientFundsEventDTOBase { }

    [Event("InsufficientFunds")]
    public class InsufficientFundsEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "accessCharge", 1, false)]
        public virtual BigInteger AccessCharge { get; set; }
        [Parameter("uint256", "amountProvided", 2, false)]
        public virtual BigInteger AmountProvided { get; set; }
    }

    public partial class SetStatusCodeEventDTO : SetStatusCodeEventDTOBase { }

    [Event("SetStatusCode")]
    public class SetStatusCodeEventDTOBase : IEventDTO
    {
        [Parameter("int256", "statusCode", 1, false)]
        public virtual BigInteger StatusCode { get; set; }
    }

    public partial class PublishEventDTO : PublishEventDTOBase { }

    [Event("Publish")]
    public class PublishEventDTOBase : IEventDTO
    {
        [Parameter("bool", "requestStatus", 1, false)]
        public virtual bool RequestStatus { get; set; }
        [Parameter("int256", "statusCode", 2, false)]
        public virtual BigInteger StatusCode { get; set; }
        [Parameter("string", "objectHash", 3, false)]
        public virtual string ObjectHash { get; set; }
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

    public partial class ObjectMetaChangedEventDTO : ObjectMetaChangedEventDTOBase { }

    [Event("ObjectMetaChanged")]
    public class ObjectMetaChangedEventDTOBase : IEventDTO
    {
        [Parameter("bytes", "key", 1, false)]
        public virtual byte[] Key { get; set; }
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

    public partial class RequestMapOutputDTO : RequestMapOutputDTOBase { }

    [FunctionOutput]
    public class RequestMapOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "originator", 1)]
        public virtual string Originator { get; set; }
        [Parameter("uint256", "amountPaid", 2)]
        public virtual BigInteger AmountPaid { get; set; }
        [Parameter("int8", "status", 3)]
        public virtual sbyte Status { get; set; }
        [Parameter("uint256", "settled", 4)]
        public virtual BigInteger Settled { get; set; }
    }





    public partial class ContentContractAddressOutputDTO : ContentContractAddressOutputDTOBase { }

    [FunctionOutput]
    public class ContentContractAddressOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class IsAdminOutputDTO : IsAdminOutputDTOBase { }

    [FunctionOutput]
    public class IsAdminOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class StatusCodeOutputDTO : StatusCodeOutputDTOBase { }

    [FunctionOutput]
    public class StatusCodeOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("int256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class VisibilityOutputDTO : VisibilityOutputDTOBase { }

    [FunctionOutput]
    public class VisibilityOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class AddressKMSOutputDTO : AddressKMSOutputDTOBase { }

    [FunctionOutput]
    public class AddressKMSOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class CountVersionHashesOutputDTO : CountVersionHashesOutputDTOBase { }

    [FunctionOutput]
    public class CountVersionHashesOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ContentTypeOutputDTO : ContentTypeOutputDTOBase { }

    [FunctionOutput]
    public class ContentTypeOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class CommitPendingOutputDTO : CommitPendingOutputDTOBase { }

    [FunctionOutput]
    public class CommitPendingOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class GetAccessInfoOutputDTO : GetAccessInfoOutputDTOBase { }

    [FunctionOutput]
    public class GetAccessInfoOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
        [Parameter("uint8", "", 2)]
        public virtual byte ReturnValue2 { get; set; }
        [Parameter("uint256", "", 3)]
        public virtual BigInteger ReturnValue3 { get; set; }
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

    public partial class AccessChargeOutputDTO : AccessChargeOutputDTOBase { }

    [FunctionOutput]
    public class AccessChargeOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
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

    public partial class GetAccessInfoV3OutputDTO : GetAccessInfoV3OutputDTOBase { }

    [FunctionOutput]
    public class GetAccessInfoV3OutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
        [Parameter("uint8", "", 2)]
        public virtual byte ReturnValue2 { get; set; }
        [Parameter("uint256", "", 3)]
        public virtual BigInteger ReturnValue3 { get; set; }
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

    public partial class RequestIDOutputDTO : RequestIDOutputDTOBase { }

    [FunctionOutput]
    public class RequestIDOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
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





    public partial class GetKMSInfoOutputDTO : GetKMSInfoOutputDTOBase { }

    [FunctionOutput]
    public class GetKMSInfoOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
        [Parameter("string", "", 2)]
        public virtual string ReturnValue2 { get; set; }
    }



    public partial class GetMetaOutputDTO : GetMetaOutputDTOBase { }

    [FunctionOutput]
    public class GetMetaOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bytes", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class ContentSpaceOutputDTO : ContentSpaceOutputDTOBase { }

    [FunctionOutput]
    public class ContentSpaceOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class LibraryAddressOutputDTO : LibraryAddressOutputDTOBase { }

    [FunctionOutput]
    public class LibraryAddressOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class GetCustomInfoOutputDTO : GetCustomInfoOutputDTOBase { }

    [FunctionOutput]
    public class GetCustomInfoOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
        [Parameter("uint8", "", 2)]
        public virtual byte ReturnValue2 { get; set; }
        [Parameter("uint256", "", 3)]
        public virtual BigInteger ReturnValue3 { get; set; }
    }





    public partial class CanPublishOutputDTO : CanPublishOutputDTOBase { }

    [FunctionOutput]
    public class CanPublishOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class ObjectHashOutputDTO : ObjectHashOutputDTOBase { }

    [FunctionOutput]
    public class ObjectHashOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }


}
