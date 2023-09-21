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

namespace Elv.NET.Contracts.BaseContentSpace.ContractDefinition
{


    public partial class BaseContentSpaceDeployment : BaseContentSpaceDeploymentBase
    {
        public BaseContentSpaceDeployment() : base(BYTECODE) { }
        public BaseContentSpaceDeployment(string byteCode) : base(byteCode) { }
    }

    public class BaseContentSpaceDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public BaseContentSpaceDeploymentBase() : base(BYTECODE) { }
        public BaseContentSpaceDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("string", "content_space_name", 1)]
        public virtual string ContentSpaceName { get; set; }
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

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
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

    public partial class SubmitNodeFunction : SubmitNodeFunctionBase { }

    [Function("submitNode")]
    public class SubmitNodeFunctionBase : FunctionMessage
    {
        [Parameter("bytes", "_locator", 1)]
        public virtual byte[] Locator { get; set; }
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

    public partial class FindTypeByHashFunction : FindTypeByHashFunctionBase { }

    [Function("findTypeByHash", "address")]
    public class FindTypeByHashFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "typeHash", 1)]
        public virtual byte[] TypeHash { get; set; }
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

    public partial class IsAdminFunction : IsAdminFunctionBase { }

    [Function("isAdmin", "bool")]
    public class IsAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "_candidate", 1)]
        public virtual string Candidate { get; set; }
    }

    public partial class CanNodePublishFunction : CanNodePublishFunctionBase { }

    [Function("canNodePublish", "bool")]
    public class CanNodePublishFunctionBase : FunctionMessage
    {
        [Parameter("address", "candidate", 1)]
        public virtual string Candidate { get; set; }
    }

    public partial class GetKMSInfoFunction : GetKMSInfoFunctionBase { }

    [Function("getKMSInfo", typeof(GetKMSInfoOutputDTO))]
    public class GetKMSInfoFunctionBase : FunctionMessage
    {
        [Parameter("string", "_kmsID", 1)]
        public virtual string KmsID { get; set; }
        [Parameter("bytes", "prefix", 2)]
        public virtual byte[] Prefix { get; set; }
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
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class ValidTypeFunction : ValidTypeFunctionBase { }

    [Function("validType", "bool")]
    public class ValidTypeFunctionBase : FunctionMessage
    {
        [Parameter("address", "content_type", 1)]
        public virtual string ContentType { get; set; }
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

    public partial class CreateLibraryFunction : CreateLibraryFunctionBase { }

    [Function("createLibrary", "address")]
    public class CreateLibraryFunctionBase : FunctionMessage
    {
        [Parameter("address", "address_KMS", 1)]
        public virtual string AddressKms { get; set; }
    }

    public partial class KillFunction : KillFunctionBase { }

    [Function("kill")]
    public class KillFunctionBase : FunctionMessage
    {

    }

    public partial class NumActiveNodesFunction : NumActiveNodesFunctionBase { }

    [Function("numActiveNodes", "uint256")]
    public class NumActiveNodesFunctionBase : FunctionMessage
    {

    }

    public partial class LibraryFactoryFunction : LibraryFactoryFunctionBase { }

    [Function("libraryFactory", "address")]
    public class LibraryFactoryFunctionBase : FunctionMessage
    {

    }

    public partial class ConfirmCommitFunction : ConfirmCommitFunctionBase { }

    [Function("confirmCommit", "bool")]
    public class ConfirmCommitFunctionBase : FunctionMessage
    {

    }

    public partial class ActiveNodeLocatorsFunction : ActiveNodeLocatorsFunctionBase { }

    [Function("activeNodeLocators", "bytes")]
    public class ActiveNodeLocatorsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ActiveNodeAddressesFunction : ActiveNodeAddressesFunctionBase { }

    [Function("activeNodeAddresses", "address")]
    public class ActiveNodeAddressesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class VersionFunction : VersionFunctionBase { }

    [Function("version", "bytes32")]
    public class VersionFunctionBase : FunctionMessage
    {

    }

    public partial class CreateGroupFunction : CreateGroupFunctionBase { }

    [Function("createGroup", "address")]
    public class CreateGroupFunctionBase : FunctionMessage
    {

    }

    public partial class GetKMSIDFunction : GetKMSIDFunctionBase { }

    [Function("getKMSID", "string")]
    public class GetKMSIDFunctionBase : FunctionMessage
    {
        [Parameter("address", "_kmsAddr", 1)]
        public virtual string KmsAddr { get; set; }
    }

    public partial class SetFactoryFunction : SetFactoryFunctionBase { }

    [Function("setFactory")]
    public class SetFactoryFunctionBase : FunctionMessage
    {
        [Parameter("address", "new_factory", 1)]
        public virtual string NewFactory { get; set; }
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

    public partial class UserWalletsFunction : UserWalletsFunctionBase { }

    [Function("userWallets", "address")]
    public class UserWalletsFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class AddNodeFunction : AddNodeFunctionBase { }

    [Function("addNode")]
    public class AddNodeFunctionBase : FunctionMessage
    {
        [Parameter("address", "_nodeAddr", 1)]
        public virtual string NodeAddr { get; set; }
        [Parameter("bytes", "_locator", 2)]
        public virtual byte[] Locator { get; set; }
    }

    public partial class HasEditorRightFunction : HasEditorRightFunctionBase { }

    [Function("hasEditorRight", "bool")]
    public class HasEditorRightFunctionBase : FunctionMessage
    {
        [Parameter("address", "candidate", 1)]
        public virtual string Candidate { get; set; }
    }

    public partial class PendingNodeLocatorsFunction : PendingNodeLocatorsFunctionBase { }

    [Function("pendingNodeLocators", "bytes")]
    public class PendingNodeLocatorsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class PendingNodeAddressesFunction : PendingNodeAddressesFunctionBase { }

    [Function("pendingNodeAddresses", "address")]
    public class PendingNodeAddressesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
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

    public partial class DescriptionFunction : DescriptionFunctionBase { }

    [Function("description", "string")]
    public class DescriptionFunctionBase : FunctionMessage
    {

    }

    public partial class CreateAccessWalletFunction : CreateAccessWalletFunctionBase { }

    [Function("createAccessWallet", "address")]
    public class CreateAccessWalletFunctionBase : FunctionMessage
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

    public partial class SetWalletFactoryFunction : SetWalletFactoryFunctionBase { }

    [Function("setWalletFactory")]
    public class SetWalletFactoryFunctionBase : FunctionMessage
    {
        [Parameter("address", "new_factory", 1)]
        public virtual string NewFactory { get; set; }
    }

    public partial class CanEditFunction : CanEditFunctionBase { }

    [Function("canEdit", "bool")]
    public class CanEditFunctionBase : FunctionMessage
    {

    }

    public partial class SetGroupFactoryFunction : SetGroupFactoryFunctionBase { }

    [Function("setGroupFactory")]
    public class SetGroupFactoryFunctionBase : FunctionMessage
    {
        [Parameter("address", "new_factory", 1)]
        public virtual string NewFactory { get; set; }
    }

    public partial class SetContentFactoryFunction : SetContentFactoryFunctionBase { }

    [Function("setContentFactory")]
    public class SetContentFactoryFunctionBase : FunctionMessage
    {
        [Parameter("address", "new_factory", 1)]
        public virtual string NewFactory { get; set; }
    }

    public partial class SetKmsManagerFunction : SetKmsManagerFunctionBase { }

    [Function("setKmsManager")]
    public class SetKmsManagerFunctionBase : FunctionMessage
    {
        [Parameter("address", "_kmsManAddr", 1)]
        public virtual string KmsManAddr { get; set; }
    }

    public partial class CheckKMSFunction : CheckKMSFunctionBase { }

    [Function("checkKMS", "uint256")]
    public class CheckKMSFunctionBase : FunctionMessage
    {
        [Parameter("string", "_kmsIdStr", 1)]
        public virtual string KmsIdStr { get; set; }
    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class ContentFactoryFunction : ContentFactoryFunctionBase { }

    [Function("contentFactory", "address")]
    public class ContentFactoryFunctionBase : FunctionMessage
    {

    }

    public partial class SetDescriptionFunction : SetDescriptionFunctionBase { }

    [Function("setDescription")]
    public class SetDescriptionFunctionBase : FunctionMessage
    {
        [Parameter("string", "content_space_description", 1)]
        public virtual string ContentSpaceDescription { get; set; }
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

    public partial class CanPublishFunction : CanPublishFunctionBase { }

    [Function("canPublish", "bool")]
    public class CanPublishFunctionBase : FunctionMessage
    {
        [Parameter("address", "_candidate", 1)]
        public virtual string Candidate { get; set; }
    }

    public partial class KmsManAddrFunction : KmsManAddrFunctionBase { }

    [Function("kmsManAddr", "address")]
    public class KmsManAddrFunctionBase : FunctionMessage
    {

    }

    public partial class WhitelistedTypeFunction : WhitelistedTypeFunctionBase { }

    [Function("whitelistedType", "bool")]
    public class WhitelistedTypeFunctionBase : FunctionMessage
    {
        [Parameter("address", "content_type", 1)]
        public virtual string ContentType { get; set; }
    }

    public partial class SetLibraryFactoryFunction : SetLibraryFactoryFunctionBase { }

    [Function("setLibraryFactory")]
    public class SetLibraryFactoryFunctionBase : FunctionMessage
    {
        [Parameter("address", "new_factory", 1)]
        public virtual string NewFactory { get; set; }
    }

    public partial class GetAccessWalletFunction : GetAccessWalletFunctionBase { }

    [Function("getAccessWallet", "address")]
    public class GetAccessWalletFunctionBase : FunctionMessage
    {

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

    public partial class GroupFactoryFunction : GroupFactoryFunctionBase { }

    [Function("groupFactory", "address")]
    public class GroupFactoryFunctionBase : FunctionMessage
    {

    }

    public partial class RemoveNodeFunction : RemoveNodeFunctionBase { }

    [Function("removeNode")]
    public class RemoveNodeFunctionBase : FunctionMessage
    {
        [Parameter("address", "_nodeAddr", 1)]
        public virtual string NodeAddr { get; set; }
    }

    public partial class CreateContentTypeFunction : CreateContentTypeFunctionBase { }

    [Function("createContentType", "address")]
    public class CreateContentTypeFunctionBase : FunctionMessage
    {

    }

    public partial class CreateContentFunction : CreateContentFunctionBase { }

    [Function("createContent", "address")]
    public class CreateContentFunctionBase : FunctionMessage
    {
        [Parameter("address", "lib", 1)]
        public virtual string Lib { get; set; }
        [Parameter("address", "content_type", 2)]
        public virtual string ContentType { get; set; }
    }

    public partial class UpdateRequestFunction : UpdateRequestFunctionBase { }

    [Function("updateRequest")]
    public class UpdateRequestFunctionBase : FunctionMessage
    {

    }

    public partial class FactoryFunction : FactoryFunctionBase { }

    [Function("factory", "address")]
    public class FactoryFunctionBase : FunctionMessage
    {

    }

    public partial class WalletFactoryFunction : WalletFactoryFunctionBase { }

    [Function("walletFactory", "address")]
    public class WalletFactoryFunctionBase : FunctionMessage
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

    public partial class CheckKMSAddrFunction : CheckKMSAddrFunctionBase { }

    [Function("checkKMSAddr", "uint256")]
    public class CheckKMSAddrFunctionBase : FunctionMessage
    {
        [Parameter("address", "_kmsAddr", 1)]
        public virtual string KmsAddr { get; set; }
    }

    public partial class ApproveNodeFunction : ApproveNodeFunctionBase { }

    [Function("approveNode")]
    public class ApproveNodeFunctionBase : FunctionMessage
    {
        [Parameter("address", "_nodeAddr", 1)]
        public virtual string NodeAddr { get; set; }
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

    public partial class CreateUserWalletFunction : CreateUserWalletFunctionBase { }

    [Function("createUserWallet", "address")]
    public class CreateUserWalletFunctionBase : FunctionMessage
    {
        [Parameter("address", "_user", 1)]
        public virtual string User { get; set; }
    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class NumPendingNodesFunction : NumPendingNodesFunctionBase { }

    [Function("numPendingNodes", "uint256")]
    public class NumPendingNodesFunctionBase : FunctionMessage
    {

    }

    public partial class NodeMappingFunction : NodeMappingFunctionBase { }

    [Function("nodeMapping", "address")]
    public class NodeMappingFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class RemoveContentTypeFunction : RemoveContentTypeFunctionBase { }

    [Function("removeContentType", "bool")]
    public class RemoveContentTypeFunctionBase : FunctionMessage
    {
        [Parameter("address", "content_type", 1)]
        public virtual string ContentType { get; set; }
    }

    public partial class CreateContentTypeEventDTO : CreateContentTypeEventDTOBase { }

    [Event("CreateContentType")]
    public class CreateContentTypeEventDTOBase : IEventDTO
    {
        [Parameter("address", "contentTypeAddress", 1, false)]
        public virtual string ContentTypeAddress { get; set; }
    }

    public partial class CreateLibraryEventDTO : CreateLibraryEventDTOBase { }

    [Event("CreateLibrary")]
    public class CreateLibraryEventDTOBase : IEventDTO
    {
        [Parameter("address", "libraryAddress", 1, false)]
        public virtual string LibraryAddress { get; set; }
    }

    public partial class CreateGroupEventDTO : CreateGroupEventDTOBase { }

    [Event("CreateGroup")]
    public class CreateGroupEventDTOBase : IEventDTO
    {
        [Parameter("address", "groupAddress", 1, false)]
        public virtual string GroupAddress { get; set; }
    }

    public partial class CreateContentEventDTO : CreateContentEventDTOBase { }

    [Event("CreateContent")]
    public class CreateContentEventDTOBase : IEventDTO
    {
        [Parameter("address", "contentAddress", 1, false)]
        public virtual string ContentAddress { get; set; }
    }

    public partial class CreateAccessWalletEventDTO : CreateAccessWalletEventDTOBase { }

    [Event("CreateAccessWallet")]
    public class CreateAccessWalletEventDTOBase : IEventDTO
    {
        [Parameter("address", "wallet", 1, false)]
        public virtual string Wallet { get; set; }
    }

    public partial class BindUserWalletEventDTO : BindUserWalletEventDTOBase { }

    [Event("BindUserWallet")]
    public class BindUserWalletEventDTOBase : IEventDTO
    {
        [Parameter("address", "wallet", 1, false)]
        public virtual string Wallet { get; set; }
        [Parameter("address", "userAddr", 2, false)]
        public virtual string UserAddr { get; set; }
    }

    public partial class EngageAccountLibraryEventDTO : EngageAccountLibraryEventDTOBase { }

    [Event("EngageAccountLibrary")]
    public class EngageAccountLibraryEventDTOBase : IEventDTO
    {
        [Parameter("address", "accountAddress", 1, false)]
        public virtual string AccountAddress { get; set; }
    }

    public partial class SetFactoryEventDTO : SetFactoryEventDTOBase { }

    [Event("SetFactory")]
    public class SetFactoryEventDTOBase : IEventDTO
    {
        [Parameter("address", "factory", 1, false)]
        public virtual string Factory { get; set; }
    }

    public partial class CreateSpaceEventDTO : CreateSpaceEventDTOBase { }

    [Event("CreateSpace")]
    public class CreateSpaceEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "version", 1, false)]
        public virtual byte[] Version { get; set; }
        [Parameter("address", "owner", 2, false)]
        public virtual string Owner { get; set; }
    }

    public partial class GetAccessWalletEventDTO : GetAccessWalletEventDTOBase { }

    [Event("GetAccessWallet")]
    public class GetAccessWalletEventDTOBase : IEventDTO
    {
        [Parameter("address", "walletAddress", 1, false)]
        public virtual string WalletAddress { get; set; }
    }

    public partial class NodeSubmittedEventDTO : NodeSubmittedEventDTOBase { }

    [Event("NodeSubmitted")]
    public class NodeSubmittedEventDTOBase : IEventDTO
    {
        [Parameter("address", "addr", 1, false)]
        public virtual string Addr { get; set; }
        [Parameter("bytes", "locator", 2, false)]
        public virtual byte[] Locator { get; set; }
    }

    public partial class NodeApprovedEventDTO : NodeApprovedEventDTOBase { }

    [Event("NodeApproved")]
    public class NodeApprovedEventDTOBase : IEventDTO
    {
        [Parameter("address", "addr", 1, false)]
        public virtual string Addr { get; set; }
        [Parameter("bytes", "locator", 2, false)]
        public virtual byte[] Locator { get; set; }
    }

    public partial class AddNodeEventDTO : AddNodeEventDTOBase { }

    [Event("AddNode")]
    public class AddNodeEventDTOBase : IEventDTO
    {
        [Parameter("address", "ownerAddr", 1, false)]
        public virtual string OwnerAddr { get; set; }
        [Parameter("address", "nodeAddr", 2, false)]
        public virtual string NodeAddr { get; set; }
    }

    public partial class RemoveNodeEventDTO : RemoveNodeEventDTOBase { }

    [Event("RemoveNode")]
    public class RemoveNodeEventDTOBase : IEventDTO
    {
        [Parameter("address", "ownerAddr", 1, false)]
        public virtual string OwnerAddr { get; set; }
        [Parameter("address", "nodeAddr", 2, false)]
        public virtual string NodeAddr { get; set; }
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

    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("string", "", 1)]
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



    public partial class IsAdminOutputDTO : IsAdminOutputDTOBase { }

    [FunctionOutput]
    public class IsAdminOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class CanNodePublishOutputDTO : CanNodePublishOutputDTOBase { }

    [FunctionOutput]
    public class CanNodePublishOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
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





    public partial class NumActiveNodesOutputDTO : NumActiveNodesOutputDTOBase { }

    [FunctionOutput]
    public class NumActiveNodesOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class LibraryFactoryOutputDTO : LibraryFactoryOutputDTOBase { }

    [FunctionOutput]
    public class LibraryFactoryOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class ActiveNodeLocatorsOutputDTO : ActiveNodeLocatorsOutputDTOBase { }

    [FunctionOutput]
    public class ActiveNodeLocatorsOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bytes", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class ActiveNodeAddressesOutputDTO : ActiveNodeAddressesOutputDTOBase { }

    [FunctionOutput]
    public class ActiveNodeAddressesOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class VersionOutputDTO : VersionOutputDTOBase { }

    [FunctionOutput]
    public class VersionOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }



    public partial class GetKMSIDOutputDTO : GetKMSIDOutputDTOBase { }

    [FunctionOutput]
    public class GetKMSIDOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
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

    public partial class UserWalletsOutputDTO : UserWalletsOutputDTOBase { }

    [FunctionOutput]
    public class UserWalletsOutputDTOBase : IFunctionOutputDTO
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

    public partial class PendingNodeLocatorsOutputDTO : PendingNodeLocatorsOutputDTOBase { }

    [FunctionOutput]
    public class PendingNodeLocatorsOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bytes", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class PendingNodeAddressesOutputDTO : PendingNodeAddressesOutputDTOBase { }

    [FunctionOutput]
    public class PendingNodeAddressesOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class CanCommitOutputDTO : CanCommitOutputDTOBase { }

    [FunctionOutput]
    public class CanCommitOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class DescriptionOutputDTO : DescriptionOutputDTOBase { }

    [FunctionOutput]
    public class DescriptionOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
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







    public partial class CheckKMSOutputDTO : CheckKMSOutputDTOBase { }

    [FunctionOutput]
    public class CheckKMSOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class ContentFactoryOutputDTO : ContentFactoryOutputDTOBase { }

    [FunctionOutput]
    public class ContentFactoryOutputDTOBase : IFunctionOutputDTO
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

    public partial class CanPublishOutputDTO : CanPublishOutputDTOBase { }

    [FunctionOutput]
    public class CanPublishOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class KmsManAddrOutputDTO : KmsManAddrOutputDTOBase { }

    [FunctionOutput]
    public class KmsManAddrOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
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

    public partial class GroupFactoryOutputDTO : GroupFactoryOutputDTOBase { }

    [FunctionOutput]
    public class GroupFactoryOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }









    public partial class FactoryOutputDTO : FactoryOutputDTOBase { }

    [FunctionOutput]
    public class FactoryOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class WalletFactoryOutputDTO : WalletFactoryOutputDTOBase { }

    [FunctionOutput]
    public class WalletFactoryOutputDTOBase : IFunctionOutputDTO
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



    public partial class CheckKMSAddrOutputDTO : CheckKMSAddrOutputDTOBase { }

    [FunctionOutput]
    public class CheckKMSAddrOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class ObjectHashOutputDTO : ObjectHashOutputDTOBase { }

    [FunctionOutput]
    public class ObjectHashOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class NumPendingNodesOutputDTO : NumPendingNodesOutputDTOBase { }

    [FunctionOutput]
    public class NumPendingNodesOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class NodeMappingOutputDTO : NodeMappingOutputDTOBase { }

    [FunctionOutput]
    public class NodeMappingOutputDTOBase : IFunctionOutputDTO
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }


}
