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

namespace Elv.NET.Contracts.BaseLibrary.ContractDefinition
{


    public partial class BaseLibraryDeployment : BaseLibraryDeploymentBase
    {
        public BaseLibraryDeployment() : base(BYTECODE) { }
        public BaseLibraryDeployment(string byteCode) : base(byteCode) { }
    }

    public class BaseLibraryDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public BaseLibraryDeploymentBase() : base(BYTECODE) { }
        public BaseLibraryDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "address_KMS", 1)]
        public virtual string AddressKms { get; set; }
        [Parameter("address", "_content_space", 2)]
        public virtual string ContentSpace { get; set; }
    }

    public partial class ParentAddressFunction : ParentAddressFunctionBase { }

    [Function("parentAddress", "address")]
    public class ParentAddressFunctionBase : FunctionMessage
    {

    }

    public partial class UpdateAddressKMSFunction : UpdateAddressKMSFunctionBase { }

    [Function("updateAddressKMS")]
    public class UpdateAddressKMSFunctionBase : FunctionMessage
    {
        [Parameter("address", "address_KMS", 1)]
        public virtual string AddressKms { get; set; }
    }

    public partial class CreatorFunction : CreatorFunctionBase { }

    [Function("creator", "address")]
    public class CreatorFunctionBase : FunctionMessage
    {

    }

    public partial class CanContributeFunction : CanContributeFunctionBase { }

    [Function("canContribute", "bool")]
    public class CanContributeFunctionBase : FunctionMessage
    {
        [Parameter("address", "_candidate", 1)]
        public virtual string Candidate { get; set; }
    }

    public partial class AddContentTypeFunction : AddContentTypeFunctionBase { }

    [Function("addContentType")]
    public class AddContentTypeFunctionBase : FunctionMessage
    {
        [Parameter("address", "content_type", 1)]
        public virtual string ContentType { get; set; }
        [Parameter("address", "content_contract", 2)]
        public virtual string ContentContract { get; set; }
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

    public partial class ApprovalRequestsLengthFunction : ApprovalRequestsLengthFunctionBase { }

    [Function("approvalRequestsLength", "uint256")]
    public class ApprovalRequestsLengthFunctionBase : FunctionMessage
    {

    }

    public partial class RemoveReviewerGroupFunction : RemoveReviewerGroupFunctionBase { }

    [Function("removeReviewerGroup", "bool")]
    public class RemoveReviewerGroupFunctionBase : FunctionMessage
    {
        [Parameter("address", "group", 1)]
        public virtual string Group { get; set; }
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

    public partial class ContentTypeContractsFunction : ContentTypeContractsFunctionBase { }

    [Function("contentTypeContracts", "address")]
    public class ContentTypeContractsFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class AddAccessorGroupFunction : AddAccessorGroupFunctionBase { }

    [Function("addAccessorGroup")]
    public class AddAccessorGroupFunctionBase : FunctionMessage
    {
        [Parameter("address", "group", 1)]
        public virtual string Group { get; set; }
    }

    public partial class CreateContentFunction : CreateContentFunctionBase { }

    [Function("createContent", "address")]
    public class CreateContentFunctionBase : FunctionMessage
    {
        [Parameter("address", "content_type", 1)]
        public virtual string ContentType { get; set; }
    }

    public partial class FindTypeByHashFunction : FindTypeByHashFunctionBase { }

    [Function("findTypeByHash", "address")]
    public class FindTypeByHashFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "typeHash", 1)]
        public virtual byte[] TypeHash { get; set; }
    }

    public partial class ReviewerGroupsLengthFunction : ReviewerGroupsLengthFunctionBase { }

    [Function("reviewerGroupsLength", "uint256")]
    public class ReviewerGroupsLengthFunctionBase : FunctionMessage
    {

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

    public partial class ContributorGroupsFunction : ContributorGroupsFunctionBase { }

    [Function("contributorGroups", "address")]
    public class ContributorGroupsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class IsAdminFunction : IsAdminFunctionBase { }

    [Function("isAdmin", "bool")]
    public class IsAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "_candidate", 1)]
        public virtual string Candidate { get; set; }
    }

    public partial class VisibilityFunction : VisibilityFunctionBase { }

    [Function("visibility", "uint8")]
    public class VisibilityFunctionBase : FunctionMessage
    {

    }

    public partial class CanReviewFunction : CanReviewFunctionBase { }

    [Function("canReview", "bool")]
    public class CanReviewFunctionBase : FunctionMessage
    {
        [Parameter("address", "_candidate", 1)]
        public virtual string Candidate { get; set; }
    }

    public partial class ValidTypeFunction : ValidTypeFunctionBase { }

    [Function("validType", "bool")]
    public class ValidTypeFunctionBase : FunctionMessage
    {
        [Parameter("address", "content_type", 1)]
        public virtual string ContentType { get; set; }
    }

    public partial class AccessorGroupsFunction : AccessorGroupsFunctionBase { }

    [Function("accessorGroups", "address")]
    public class AccessorGroupsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class PublishFunction : PublishFunctionBase { }

    [Function("publish", "bool")]
    public class PublishFunctionBase : FunctionMessage
    {
        [Parameter("address", "contentObj", 1)]
        public virtual string ContentObj { get; set; }
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

    public partial class CommitPendingFunction : CommitPendingFunctionBase { }

    [Function("commitPending", "bool")]
    public class CommitPendingFunctionBase : FunctionMessage
    {

    }

    public partial class RemoveContributorGroupFunction : RemoveContributorGroupFunctionBase { }

    [Function("removeContributorGroup", "bool")]
    public class RemoveContributorGroupFunctionBase : FunctionMessage
    {
        [Parameter("address", "group", 1)]
        public virtual string Group { get; set; }
    }

    public partial class RequiresReviewFunction : RequiresReviewFunctionBase { }

    [Function("requiresReview", "bool")]
    public class RequiresReviewFunctionBase : FunctionMessage
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

    public partial class ContributorGroupsLengthFunction : ContributorGroupsLengthFunctionBase { }

    [Function("contributorGroupsLength", "uint256")]
    public class ContributorGroupsLengthFunctionBase : FunctionMessage
    {

    }

    public partial class SubmitApprovalRequestFunction : SubmitApprovalRequestFunctionBase { }

    [Function("submitApprovalRequest", "bool")]
    public class SubmitApprovalRequestFunctionBase : FunctionMessage
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

    public partial class GetPendingApprovalRequestFunction : GetPendingApprovalRequestFunctionBase { }

    [Function("getPendingApprovalRequest", "address")]
    public class GetPendingApprovalRequestFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "index", 1)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class AddContributorGroupFunction : AddContributorGroupFunctionBase { }

    [Function("addContributorGroup")]
    public class AddContributorGroupFunctionBase : FunctionMessage
    {
        [Parameter("address", "group", 1)]
        public virtual string Group { get; set; }
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

    public partial class ApproveContentFunction : ApproveContentFunctionBase { }

    [Function("approveContent", "bool")]
    public class ApproveContentFunctionBase : FunctionMessage
    {
        [Parameter("address", "content_contract", 1)]
        public virtual string ContentContract { get; set; }
        [Parameter("bool", "approved", 2)]
        public virtual bool Approved { get; set; }
        [Parameter("string", "note", 3)]
        public virtual string Note { get; set; }
    }

    public partial class DeleteContentFunction : DeleteContentFunctionBase { }

    [Function("deleteContent")]
    public class DeleteContentFunctionBase : FunctionMessage
    {
        [Parameter("address", "_contentAddr", 1)]
        public virtual string ContentAddr { get; set; }
    }

    public partial class ApprovalRequestsFunction : ApprovalRequestsFunctionBase { }

    [Function("approvalRequests", "address")]
    public class ApprovalRequestsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class ReviewerGroupsFunction : ReviewerGroupsFunctionBase { }

    [Function("reviewerGroups", "address")]
    public class ReviewerGroupsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
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

    public partial class ContentTypesFunction : ContentTypesFunctionBase { }

    [Function("contentTypes", "address")]
    public class ContentTypesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CanPublish1Function : CanPublish1FunctionBase { }

    [Function("canPublish", "bool")]
    public class CanPublish1FunctionBase : FunctionMessage
    {
        [Parameter("address", "_candidate", 1)]
        public virtual string Candidate { get; set; }
    }

    public partial class WhitelistedTypeFunction : WhitelistedTypeFunctionBase { }

    [Function("whitelistedType", "bool")]
    public class WhitelistedTypeFunctionBase : FunctionMessage
    {
        [Parameter("address", "content_type", 1)]
        public virtual string ContentType { get; set; }
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

    public partial class UpdateRequestFunction : UpdateRequestFunctionBase { }

    [Function("updateRequest")]
    public class UpdateRequestFunctionBase : FunctionMessage
    {

    }

    public partial class ContentTypesLengthFunction : ContentTypesLengthFunctionBase { }

    [Function("contentTypesLength", "uint256")]
    public class ContentTypesLengthFunctionBase : FunctionMessage
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

    public partial class AddReviewerGroupFunction : AddReviewerGroupFunctionBase { }

    [Function("addReviewerGroup")]
    public class AddReviewerGroupFunctionBase : FunctionMessage
    {
        [Parameter("address", "group", 1)]
        public virtual string Group { get; set; }
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

    public partial class PutMetaFunction : PutMetaFunctionBase { }

    [Function("putMeta")]
    public class PutMetaFunctionBase : FunctionMessage
    {
        [Parameter("bytes", "key", 1)]
        public virtual byte[] Key { get; set; }
        [Parameter("bytes", "value", 2)]
        public virtual byte[] Value { get; set; }
    }

    public partial class AccessorGroupsLengthFunction : AccessorGroupsLengthFunctionBase { }

    [Function("accessorGroupsLength", "uint256")]
    public class AccessorGroupsLengthFunctionBase : FunctionMessage
    {

    }

    public partial class RemoveAccessorGroupFunction : RemoveAccessorGroupFunctionBase { }

    [Function("removeAccessorGroup", "bool")]
    public class RemoveAccessorGroupFunctionBase : FunctionMessage
    {
        [Parameter("address", "group", 1)]
        public virtual string Group { get; set; }
    }


    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class RemoveContentTypeFunction : RemoveContentTypeFunctionBase { }

    [Function("removeContentType", "bool")]
    public class RemoveContentTypeFunctionBase : FunctionMessage
    {
        [Parameter("address", "content_type", 1)]
        public virtual string ContentType { get; set; }
    }

    public partial class ContentObjectCreatedEventDTO : ContentObjectCreatedEventDTOBase { }

    [Event("ContentObjectCreated")]
    public class ContentObjectCreatedEventDTOBase : IEventDTO
    {
        [Parameter("address", "contentAddress", 1, false)]
        public virtual string ContentAddress { get; set; }
        [Parameter("address", "content_type", 2, false)]
        public virtual string ContentType { get; set; }
        [Parameter("address", "spaceAddress", 3, false)]
        public virtual string SpaceAddress { get; set; }
    }

    public partial class ContentObjectDeletedEventDTO : ContentObjectDeletedEventDTOBase { }

    [Event("ContentObjectDeleted")]
    public class ContentObjectDeletedEventDTOBase : IEventDTO
    {
        [Parameter("address", "contentAddress", 1, false)]
        public virtual string ContentAddress { get; set; }
        [Parameter("address", "spaceAddress", 2, false)]
        public virtual string SpaceAddress { get; set; }
    }

    public partial class ContributorGroupAddedEventDTO : ContributorGroupAddedEventDTOBase { }

    [Event("ContributorGroupAdded")]
    public class ContributorGroupAddedEventDTOBase : IEventDTO
    {
        [Parameter("address", "group", 1, false)]
        public virtual string Group { get; set; }
    }

    public partial class ContributorGroupRemovedEventDTO : ContributorGroupRemovedEventDTOBase { }

    [Event("ContributorGroupRemoved")]
    public class ContributorGroupRemovedEventDTOBase : IEventDTO
    {
        [Parameter("address", "group", 1, false)]
        public virtual string Group { get; set; }
    }

    public partial class ReviewerGroupAddedEventDTO : ReviewerGroupAddedEventDTOBase { }

    [Event("ReviewerGroupAdded")]
    public class ReviewerGroupAddedEventDTOBase : IEventDTO
    {
        [Parameter("address", "group", 1, false)]
        public virtual string Group { get; set; }
    }

    public partial class ReviewerGroupRemovedEventDTO : ReviewerGroupRemovedEventDTOBase { }

    [Event("ReviewerGroupRemoved")]
    public class ReviewerGroupRemovedEventDTOBase : IEventDTO
    {
        [Parameter("address", "group", 1, false)]
        public virtual string Group { get; set; }
    }

    public partial class AccessorGroupAddedEventDTO : AccessorGroupAddedEventDTOBase { }

    [Event("AccessorGroupAdded")]
    public class AccessorGroupAddedEventDTOBase : IEventDTO
    {
        [Parameter("address", "group", 1, false)]
        public virtual string Group { get; set; }
    }

    public partial class AccessorGroupRemovedEventDTO : AccessorGroupRemovedEventDTOBase { }

    [Event("AccessorGroupRemoved")]
    public class AccessorGroupRemovedEventDTOBase : IEventDTO
    {
        [Parameter("address", "group", 1, false)]
        public virtual string Group { get; set; }
    }

    public partial class UnauthorizedOperationEventDTO : UnauthorizedOperationEventDTOBase { }

    [Event("UnauthorizedOperation")]
    public class UnauthorizedOperationEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "operationCode", 1, false)]
        public virtual BigInteger OperationCode { get; set; }
        [Parameter("address", "candidate", 2, false)]
        public virtual string Candidate { get; set; }
    }

    public partial class ApproveContentRequestEventDTO : ApproveContentRequestEventDTOBase { }

    [Event("ApproveContentRequest")]
    public class ApproveContentRequestEventDTOBase : IEventDTO
    {
        [Parameter("address", "contentAddress", 1, false)]
        public virtual string ContentAddress { get; set; }
        [Parameter("address", "submitter", 2, false)]
        public virtual string Submitter { get; set; }
    }

    public partial class ApproveContentEventDTO : ApproveContentEventDTOBase { }

    [Event("ApproveContent")]
    public class ApproveContentEventDTOBase : IEventDTO
    {
        [Parameter("address", "contentAddress", 1, false)]
        public virtual string ContentAddress { get; set; }
        [Parameter("bool", "approved", 2, false)]
        public virtual bool Approved { get; set; }
        [Parameter("string", "note", 3, false)]
        public virtual string Note { get; set; }
    }

    public partial class UpdateKmsAddressEventDTO : UpdateKmsAddressEventDTOBase { }

    [Event("UpdateKmsAddress")]
    public class UpdateKmsAddressEventDTOBase : IEventDTO
    {
        [Parameter("address", "addressKms", 1, false)]
        public virtual string AddressKms { get; set; }
    }

    public partial class ContentTypeAddedEventDTO : ContentTypeAddedEventDTOBase { }

    [Event("ContentTypeAdded")]
    public class ContentTypeAddedEventDTOBase : IEventDTO
    {
        [Parameter("address", "contentType", 1, false)]
        public virtual string ContentType { get; set; }
        [Parameter("address", "contentContract", 2, false)]
        public virtual string ContentContract { get; set; }
    }

    public partial class ContentTypeRemovedEventDTO : ContentTypeRemovedEventDTOBase { }

    [Event("ContentTypeRemoved")]
    public class ContentTypeRemovedEventDTOBase : IEventDTO
    {
        [Parameter("address", "contentType", 1, false)]
        public virtual string ContentType { get; set; }
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

    public partial class CanContributeOutputDTO : CanContributeOutputDTOBase { }

    [FunctionOutput]
    public class CanContributeOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
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

    public partial class ApprovalRequestsLengthOutputDTO : ApprovalRequestsLengthOutputDTOBase { }

    [FunctionOutput]
    public class ApprovalRequestsLengthOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }





    public partial class ContentTypeContractsOutputDTO : ContentTypeContractsOutputDTOBase { }

    [FunctionOutput]
    public class ContentTypeContractsOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }





    public partial class FindTypeByHashOutputDTO : FindTypeByHashOutputDTOBase { }

    [FunctionOutput]
    public class FindTypeByHashOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class ReviewerGroupsLengthOutputDTO : ReviewerGroupsLengthOutputDTOBase { }

    [FunctionOutput]
    public class ReviewerGroupsLengthOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class ContributorGroupsOutputDTO : ContributorGroupsOutputDTOBase { }

    [FunctionOutput]
    public class ContributorGroupsOutputDTOBase : IFunctionOutputDTO
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

    public partial class VisibilityOutputDTO : VisibilityOutputDTOBase { }

    [FunctionOutput]
    public class VisibilityOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class CanReviewOutputDTO : CanReviewOutputDTOBase { }

    [FunctionOutput]
    public class CanReviewOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class ValidTypeOutputDTO : ValidTypeOutputDTOBase { }

    [FunctionOutput]
    public class ValidTypeOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class AccessorGroupsOutputDTO : AccessorGroupsOutputDTOBase { }

    [FunctionOutput]
    public class AccessorGroupsOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
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

    public partial class CommitPendingOutputDTO : CommitPendingOutputDTOBase { }

    [FunctionOutput]
    public class CommitPendingOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }



    public partial class RequiresReviewOutputDTO : RequiresReviewOutputDTOBase { }

    [FunctionOutput]
    public class RequiresReviewOutputDTOBase : IFunctionOutputDTO
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





    public partial class ContributorGroupsLengthOutputDTO : ContributorGroupsLengthOutputDTOBase { }

    [FunctionOutput]
    public class ContributorGroupsLengthOutputDTOBase : IFunctionOutputDTO
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

    public partial class GetPendingApprovalRequestOutputDTO : GetPendingApprovalRequestOutputDTOBase { }

    [FunctionOutput]
    public class GetPendingApprovalRequestOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
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





    public partial class ApprovalRequestsOutputDTO : ApprovalRequestsOutputDTOBase { }

    [FunctionOutput]
    public class ApprovalRequestsOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class ReviewerGroupsOutputDTO : ReviewerGroupsOutputDTOBase { }

    [FunctionOutput]
    public class ReviewerGroupsOutputDTOBase : IFunctionOutputDTO
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



    public partial class ContentTypesOutputDTO : ContentTypesOutputDTOBase { }

    [FunctionOutput]
    public class ContentTypesOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class CanPublish1OutputDTO : CanPublish1OutputDTOBase { }

    [FunctionOutput]
    public class CanPublish1OutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class WhitelistedTypeOutputDTO : WhitelistedTypeOutputDTOBase { }

    [FunctionOutput]
    public class WhitelistedTypeOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
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



    public partial class ContentTypesLengthOutputDTO : ContentTypesLengthOutputDTOBase { }

    [FunctionOutput]
    public class ContentTypesLengthOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
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





    public partial class AccessorGroupsLengthOutputDTO : AccessorGroupsLengthOutputDTOBase { }

    [FunctionOutput]
    public class AccessorGroupsLengthOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



}
