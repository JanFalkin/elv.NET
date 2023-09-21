using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Elv.NET.Contracts.BaseLibrary.ContractDefinition;

namespace Elv.NET.Contracts.BaseLibrary
{
    public partial class BaseLibraryService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, BaseLibraryDeployment baseLibraryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<BaseLibraryDeployment>().SendRequestAndWaitForReceiptAsync(baseLibraryDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, BaseLibraryDeployment baseLibraryDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<BaseLibraryDeployment>().SendRequestAsync(baseLibraryDeployment);
        }

        public static async Task<BaseLibraryService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, BaseLibraryDeployment baseLibraryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, baseLibraryDeployment, cancellationTokenSource);
            return new BaseLibraryService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3 { get; }

        public ContractHandler ContractHandler { get; }

        public BaseLibraryService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public BaseLibraryService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> ParentAddressQueryAsync(ParentAddressFunction parentAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ParentAddressFunction, string>(parentAddressFunction, blockParameter);
        }


        public Task<string> ParentAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ParentAddressFunction, string>(null, blockParameter);
        }

        public Task<string> UpdateAddressKMSRequestAsync(UpdateAddressKMSFunction updateAddressKMSFunction)
        {
            return ContractHandler.SendRequestAsync(updateAddressKMSFunction);
        }

        public Task<TransactionReceipt> UpdateAddressKMSRequestAndWaitForReceiptAsync(UpdateAddressKMSFunction updateAddressKMSFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(updateAddressKMSFunction, cancellationToken);
        }

        public Task<string> UpdateAddressKMSRequestAsync(string addressKms)
        {
            var updateAddressKMSFunction = new UpdateAddressKMSFunction();
            updateAddressKMSFunction.AddressKms = addressKms;

            return ContractHandler.SendRequestAsync(updateAddressKMSFunction);
        }

        public Task<TransactionReceipt> UpdateAddressKMSRequestAndWaitForReceiptAsync(string addressKms, CancellationTokenSource cancellationToken = null)
        {
            var updateAddressKMSFunction = new UpdateAddressKMSFunction();
            updateAddressKMSFunction.AddressKms = addressKms;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(updateAddressKMSFunction, cancellationToken);
        }

        public Task<string> CreatorQueryAsync(CreatorFunction creatorFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CreatorFunction, string>(creatorFunction, blockParameter);
        }


        public Task<string> CreatorQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CreatorFunction, string>(null, blockParameter);
        }

        public Task<bool> CanContributeQueryAsync(CanContributeFunction canContributeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanContributeFunction, bool>(canContributeFunction, blockParameter);
        }


        public Task<bool> CanContributeQueryAsync(string candidate, BlockParameter blockParameter = null)
        {
            var canContributeFunction = new CanContributeFunction();
            canContributeFunction.Candidate = candidate;

            return ContractHandler.QueryAsync<CanContributeFunction, bool>(canContributeFunction, blockParameter);
        }

        public Task<string> AddContentTypeRequestAsync(AddContentTypeFunction addContentTypeFunction)
        {
            return ContractHandler.SendRequestAsync(addContentTypeFunction);
        }

        public Task<TransactionReceipt> AddContentTypeRequestAndWaitForReceiptAsync(AddContentTypeFunction addContentTypeFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(addContentTypeFunction, cancellationToken);
        }

        public Task<string> AddContentTypeRequestAsync(string contentType, string contentContract)
        {
            var addContentTypeFunction = new AddContentTypeFunction();
            addContentTypeFunction.ContentType = contentType;
            addContentTypeFunction.ContentContract = contentContract;

            return ContractHandler.SendRequestAsync(addContentTypeFunction);
        }

        public Task<TransactionReceipt> AddContentTypeRequestAndWaitForReceiptAsync(string contentType, string contentContract, CancellationTokenSource cancellationToken = null)
        {
            var addContentTypeFunction = new AddContentTypeFunction();
            addContentTypeFunction.ContentType = contentType;
            addContentTypeFunction.ContentContract = contentContract;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(addContentTypeFunction, cancellationToken);
        }

        public Task<string> SetRightsRequestAsync(SetRightsFunction setRightsFunction)
        {
            return ContractHandler.SendRequestAsync(setRightsFunction);
        }

        public Task<TransactionReceipt> SetRightsRequestAndWaitForReceiptAsync(SetRightsFunction setRightsFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(setRightsFunction, cancellationToken);
        }

        public Task<string> SetRightsRequestAsync(string stakeholder, byte accessType, byte access)
        {
            var setRightsFunction = new SetRightsFunction();
            setRightsFunction.Stakeholder = stakeholder;
            setRightsFunction.AccessType = accessType;
            setRightsFunction.Access = access;

            return ContractHandler.SendRequestAsync(setRightsFunction);
        }

        public Task<TransactionReceipt> SetRightsRequestAndWaitForReceiptAsync(string stakeholder, byte accessType, byte access, CancellationTokenSource cancellationToken = null)
        {
            var setRightsFunction = new SetRightsFunction();
            setRightsFunction.Stakeholder = stakeholder;
            setRightsFunction.AccessType = accessType;
            setRightsFunction.Access = access;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(setRightsFunction, cancellationToken);
        }

        public Task<byte> CanSeeQueryAsync(CanSeeFunction canSeeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanSeeFunction, byte>(canSeeFunction, blockParameter);
        }


        public Task<byte> CanSeeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanSeeFunction, byte>(null, blockParameter);
        }

        public Task<bool> CanConfirmQueryAsync(CanConfirmFunction canConfirmFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanConfirmFunction, bool>(canConfirmFunction, blockParameter);
        }


        public Task<bool> CanConfirmQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanConfirmFunction, bool>(null, blockParameter);
        }

        public Task<BigInteger> ApprovalRequestsLengthQueryAsync(ApprovalRequestsLengthFunction approvalRequestsLengthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ApprovalRequestsLengthFunction, BigInteger>(approvalRequestsLengthFunction, blockParameter);
        }


        public Task<BigInteger> ApprovalRequestsLengthQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ApprovalRequestsLengthFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> RemoveReviewerGroupRequestAsync(RemoveReviewerGroupFunction removeReviewerGroupFunction)
        {
            return ContractHandler.SendRequestAsync(removeReviewerGroupFunction);
        }

        public Task<TransactionReceipt> RemoveReviewerGroupRequestAndWaitForReceiptAsync(RemoveReviewerGroupFunction removeReviewerGroupFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(removeReviewerGroupFunction, cancellationToken);
        }

        public Task<string> RemoveReviewerGroupRequestAsync(string group)
        {
            var removeReviewerGroupFunction = new RemoveReviewerGroupFunction();
            removeReviewerGroupFunction.Group = group;

            return ContractHandler.SendRequestAsync(removeReviewerGroupFunction);
        }

        public Task<TransactionReceipt> RemoveReviewerGroupRequestAndWaitForReceiptAsync(string group, CancellationTokenSource cancellationToken = null)
        {
            var removeReviewerGroupFunction = new RemoveReviewerGroupFunction();
            removeReviewerGroupFunction.Group = group;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(removeReviewerGroupFunction, cancellationToken);
        }

        public Task<string> AccessRequestV3RequestAsync(AccessRequestV3Function accessRequestV3Function)
        {
            return ContractHandler.SendRequestAsync(accessRequestV3Function);
        }

        public Task<TransactionReceipt> AccessRequestV3RequestAndWaitForReceiptAsync(AccessRequestV3Function accessRequestV3Function, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(accessRequestV3Function, cancellationToken);
        }

        public Task<string> AccessRequestV3RequestAsync(List<byte[]> returnValue1, List<string> returnValue2)
        {
            var accessRequestV3Function = new AccessRequestV3Function();
            accessRequestV3Function.ReturnValue1 = returnValue1;
            accessRequestV3Function.ReturnValue2 = returnValue2;

            return ContractHandler.SendRequestAsync(accessRequestV3Function);
        }

        public Task<TransactionReceipt> AccessRequestV3RequestAndWaitForReceiptAsync(List<byte[]> returnValue1, List<string> returnValue2, CancellationTokenSource cancellationToken = null)
        {
            var accessRequestV3Function = new AccessRequestV3Function();
            accessRequestV3Function.ReturnValue1 = returnValue1;
            accessRequestV3Function.ReturnValue2 = returnValue2;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(accessRequestV3Function, cancellationToken);
        }

        public Task<string> ContentTypeContractsQueryAsync(ContentTypeContractsFunction contentTypeContractsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContentTypeContractsFunction, string>(contentTypeContractsFunction, blockParameter);
        }


        public Task<string> ContentTypeContractsQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var contentTypeContractsFunction = new ContentTypeContractsFunction();
            contentTypeContractsFunction.ReturnValue1 = returnValue1;

            return ContractHandler.QueryAsync<ContentTypeContractsFunction, string>(contentTypeContractsFunction, blockParameter);
        }

        public Task<string> AddAccessorGroupRequestAsync(AddAccessorGroupFunction addAccessorGroupFunction)
        {
            return ContractHandler.SendRequestAsync(addAccessorGroupFunction);
        }

        public Task<TransactionReceipt> AddAccessorGroupRequestAndWaitForReceiptAsync(AddAccessorGroupFunction addAccessorGroupFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(addAccessorGroupFunction, cancellationToken);
        }

        public Task<string> AddAccessorGroupRequestAsync(string group)
        {
            var addAccessorGroupFunction = new AddAccessorGroupFunction();
            addAccessorGroupFunction.Group = group;

            return ContractHandler.SendRequestAsync(addAccessorGroupFunction);
        }

        public Task<TransactionReceipt> AddAccessorGroupRequestAndWaitForReceiptAsync(string group, CancellationTokenSource cancellationToken = null)
        {
            var addAccessorGroupFunction = new AddAccessorGroupFunction();
            addAccessorGroupFunction.Group = group;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(addAccessorGroupFunction, cancellationToken);
        }

        public Task<string> CreateContentRequestAsync(CreateContentFunction createContentFunction)
        {
            return ContractHandler.SendRequestAsync(createContentFunction);
        }

        public Task<TransactionReceipt> CreateContentRequestAndWaitForReceiptAsync(CreateContentFunction createContentFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(createContentFunction, cancellationToken);
        }

        public Task<string> CreateContentRequestAsync(string contentType)
        {
            var createContentFunction = new CreateContentFunction();
            createContentFunction.ContentType = contentType;

            return ContractHandler.SendRequestAsync(createContentFunction);
        }

        public Task<TransactionReceipt> CreateContentRequestAndWaitForReceiptAsync(string contentType, CancellationTokenSource cancellationToken = null)
        {
            var createContentFunction = new CreateContentFunction();
            createContentFunction.ContentType = contentType;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(createContentFunction, cancellationToken);
        }

        public Task<string> FindTypeByHashQueryAsync(FindTypeByHashFunction findTypeByHashFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FindTypeByHashFunction, string>(findTypeByHashFunction, blockParameter);
        }


        public Task<string> FindTypeByHashQueryAsync(byte[] typeHash, BlockParameter blockParameter = null)
        {
            var findTypeByHashFunction = new FindTypeByHashFunction();
            findTypeByHashFunction.TypeHash = typeHash;

            return ContractHandler.QueryAsync<FindTypeByHashFunction, string>(findTypeByHashFunction, blockParameter);
        }

        public Task<BigInteger> ReviewerGroupsLengthQueryAsync(ReviewerGroupsLengthFunction reviewerGroupsLengthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReviewerGroupsLengthFunction, BigInteger>(reviewerGroupsLengthFunction, blockParameter);
        }


        public Task<BigInteger> ReviewerGroupsLengthQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReviewerGroupsLengthFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> SetGroupRightsRequestAsync(SetGroupRightsFunction setGroupRightsFunction)
        {
            return ContractHandler.SendRequestAsync(setGroupRightsFunction);
        }

        public Task<TransactionReceipt> SetGroupRightsRequestAndWaitForReceiptAsync(SetGroupRightsFunction setGroupRightsFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(setGroupRightsFunction, cancellationToken);
        }

        public Task<string> SetGroupRightsRequestAsync(string group, byte accessType, byte access)
        {
            var setGroupRightsFunction = new SetGroupRightsFunction();
            setGroupRightsFunction.Group = group;
            setGroupRightsFunction.AccessType = accessType;
            setGroupRightsFunction.Access = access;

            return ContractHandler.SendRequestAsync(setGroupRightsFunction);
        }

        public Task<TransactionReceipt> SetGroupRightsRequestAndWaitForReceiptAsync(string group, byte accessType, byte access, CancellationTokenSource cancellationToken = null)
        {
            var setGroupRightsFunction = new SetGroupRightsFunction();
            setGroupRightsFunction.Group = group;
            setGroupRightsFunction.AccessType = accessType;
            setGroupRightsFunction.Access = access;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(setGroupRightsFunction, cancellationToken);
        }

        public Task<string> ContributorGroupsQueryAsync(ContributorGroupsFunction contributorGroupsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContributorGroupsFunction, string>(contributorGroupsFunction, blockParameter);
        }


        public Task<string> ContributorGroupsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var contributorGroupsFunction = new ContributorGroupsFunction();
            contributorGroupsFunction.ReturnValue1 = returnValue1;

            return ContractHandler.QueryAsync<ContributorGroupsFunction, string>(contributorGroupsFunction, blockParameter);
        }

        public Task<bool> IsAdminQueryAsync(IsAdminFunction isAdminFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsAdminFunction, bool>(isAdminFunction, blockParameter);
        }


        public Task<bool> IsAdminQueryAsync(string candidate, BlockParameter blockParameter = null)
        {
            var isAdminFunction = new IsAdminFunction();
            isAdminFunction.Candidate = candidate;

            return ContractHandler.QueryAsync<IsAdminFunction, bool>(isAdminFunction, blockParameter);
        }

        public Task<byte> VisibilityQueryAsync(VisibilityFunction visibilityFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VisibilityFunction, byte>(visibilityFunction, blockParameter);
        }


        public Task<byte> VisibilityQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VisibilityFunction, byte>(null, blockParameter);
        }

        public Task<bool> CanReviewQueryAsync(CanReviewFunction canReviewFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanReviewFunction, bool>(canReviewFunction, blockParameter);
        }


        public Task<bool> CanReviewQueryAsync(string candidate, BlockParameter blockParameter = null)
        {
            var canReviewFunction = new CanReviewFunction();
            canReviewFunction.Candidate = candidate;

            return ContractHandler.QueryAsync<CanReviewFunction, bool>(canReviewFunction, blockParameter);
        }

        public Task<bool> ValidTypeQueryAsync(ValidTypeFunction validTypeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ValidTypeFunction, bool>(validTypeFunction, blockParameter);
        }


        public Task<bool> ValidTypeQueryAsync(string contentType, BlockParameter blockParameter = null)
        {
            var validTypeFunction = new ValidTypeFunction();
            validTypeFunction.ContentType = contentType;

            return ContractHandler.QueryAsync<ValidTypeFunction, bool>(validTypeFunction, blockParameter);
        }

        public Task<string> AccessorGroupsQueryAsync(AccessorGroupsFunction accessorGroupsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AccessorGroupsFunction, string>(accessorGroupsFunction, blockParameter);
        }


        public Task<string> AccessorGroupsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var accessorGroupsFunction = new AccessorGroupsFunction();
            accessorGroupsFunction.ReturnValue1 = returnValue1;

            return ContractHandler.QueryAsync<AccessorGroupsFunction, string>(accessorGroupsFunction, blockParameter);
        }

        public Task<string> PublishRequestAsync(PublishFunction publishFunction)
        {
            return ContractHandler.SendRequestAsync(publishFunction);
        }

        public Task<TransactionReceipt> PublishRequestAndWaitForReceiptAsync(PublishFunction publishFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(publishFunction, cancellationToken);
        }

        public Task<string> PublishRequestAsync(string contentObj)
        {
            var publishFunction = new PublishFunction();
            publishFunction.ContentObj = contentObj;

            return ContractHandler.SendRequestAsync(publishFunction);
        }

        public Task<TransactionReceipt> PublishRequestAndWaitForReceiptAsync(string contentObj, CancellationTokenSource cancellationToken = null)
        {
            var publishFunction = new PublishFunction();
            publishFunction.ContentObj = contentObj;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(publishFunction, cancellationToken);
        }

        public Task<string> AddressKMSQueryAsync(AddressKMSFunction addressKMSFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AddressKMSFunction, string>(addressKMSFunction, blockParameter);
        }


        public Task<string> AddressKMSQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AddressKMSFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> CountVersionHashesQueryAsync(CountVersionHashesFunction countVersionHashesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CountVersionHashesFunction, BigInteger>(countVersionHashesFunction, blockParameter);
        }


        public Task<BigInteger> CountVersionHashesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CountVersionHashesFunction, BigInteger>(null, blockParameter);
        }

        public Task<bool> CommitPendingQueryAsync(CommitPendingFunction commitPendingFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CommitPendingFunction, bool>(commitPendingFunction, blockParameter);
        }


        public Task<bool> CommitPendingQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CommitPendingFunction, bool>(null, blockParameter);
        }

        public Task<string> RemoveContributorGroupRequestAsync(RemoveContributorGroupFunction removeContributorGroupFunction)
        {
            return ContractHandler.SendRequestAsync(removeContributorGroupFunction);
        }

        public Task<TransactionReceipt> RemoveContributorGroupRequestAndWaitForReceiptAsync(RemoveContributorGroupFunction removeContributorGroupFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(removeContributorGroupFunction, cancellationToken);
        }

        public Task<string> RemoveContributorGroupRequestAsync(string group)
        {
            var removeContributorGroupFunction = new RemoveContributorGroupFunction();
            removeContributorGroupFunction.Group = group;

            return ContractHandler.SendRequestAsync(removeContributorGroupFunction);
        }

        public Task<TransactionReceipt> RemoveContributorGroupRequestAndWaitForReceiptAsync(string group, CancellationTokenSource cancellationToken = null)
        {
            var removeContributorGroupFunction = new RemoveContributorGroupFunction();
            removeContributorGroupFunction.Group = group;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(removeContributorGroupFunction, cancellationToken);
        }

        public Task<bool> RequiresReviewQueryAsync(RequiresReviewFunction requiresReviewFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RequiresReviewFunction, bool>(requiresReviewFunction, blockParameter);
        }


        public Task<bool> RequiresReviewQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RequiresReviewFunction, bool>(null, blockParameter);
        }

        public Task<BigInteger> ObjectTimestampQueryAsync(ObjectTimestampFunction objectTimestampFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ObjectTimestampFunction, BigInteger>(objectTimestampFunction, blockParameter);
        }


        public Task<BigInteger> ObjectTimestampQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ObjectTimestampFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> KillRequestAsync(KillFunction killFunction)
        {
            return ContractHandler.SendRequestAsync(killFunction);
        }

        public Task<string> KillRequestAsync()
        {
            return ContractHandler.SendRequestAsync<KillFunction>();
        }

        public Task<TransactionReceipt> KillRequestAndWaitForReceiptAsync(KillFunction killFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(killFunction, cancellationToken);
        }

        public Task<TransactionReceipt> KillRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync<KillFunction>(null, cancellationToken);
        }

        public Task<string> ConfirmCommitRequestAsync(ConfirmCommitFunction confirmCommitFunction)
        {
            return ContractHandler.SendRequestAsync(confirmCommitFunction);
        }

        public Task<string> ConfirmCommitRequestAsync()
        {
            return ContractHandler.SendRequestAsync<ConfirmCommitFunction>();
        }

        public Task<TransactionReceipt> ConfirmCommitRequestAndWaitForReceiptAsync(ConfirmCommitFunction confirmCommitFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(confirmCommitFunction, cancellationToken);
        }

        public Task<TransactionReceipt> ConfirmCommitRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync<ConfirmCommitFunction>(null, cancellationToken);
        }

        public Task<BigInteger> ContributorGroupsLengthQueryAsync(ContributorGroupsLengthFunction contributorGroupsLengthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContributorGroupsLengthFunction, BigInteger>(contributorGroupsLengthFunction, blockParameter);
        }


        public Task<BigInteger> ContributorGroupsLengthQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContributorGroupsLengthFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> SubmitApprovalRequestRequestAsync(SubmitApprovalRequestFunction submitApprovalRequestFunction)
        {
            return ContractHandler.SendRequestAsync(submitApprovalRequestFunction);
        }

        public Task<string> SubmitApprovalRequestRequestAsync()
        {
            return ContractHandler.SendRequestAsync<SubmitApprovalRequestFunction>();
        }

        public Task<TransactionReceipt> SubmitApprovalRequestRequestAndWaitForReceiptAsync(SubmitApprovalRequestFunction submitApprovalRequestFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(submitApprovalRequestFunction, cancellationToken);
        }

        public Task<TransactionReceipt> SubmitApprovalRequestRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync<SubmitApprovalRequestFunction>(null, cancellationToken);
        }

        public Task<byte[]> VersionQueryAsync(VersionFunction versionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VersionFunction, byte[]>(versionFunction, blockParameter);
        }


        public Task<byte[]> VersionQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VersionFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> VersionAPIQueryAsync(VersionAPIFunction versionAPIFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VersionAPIFunction, byte[]>(versionAPIFunction, blockParameter);
        }


        public Task<byte[]> VersionAPIQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VersionAPIFunction, byte[]>(null, blockParameter);
        }

        public Task<string> ClearPendingRequestAsync(ClearPendingFunction clearPendingFunction)
        {
            return ContractHandler.SendRequestAsync(clearPendingFunction);
        }

        public Task<string> ClearPendingRequestAsync()
        {
            return ContractHandler.SendRequestAsync<ClearPendingFunction>();
        }

        public Task<TransactionReceipt> ClearPendingRequestAndWaitForReceiptAsync(ClearPendingFunction clearPendingFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(clearPendingFunction, cancellationToken);
        }

        public Task<TransactionReceipt> ClearPendingRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync<ClearPendingFunction>(null, cancellationToken);
        }

        public Task<string> PendingHashQueryAsync(PendingHashFunction pendingHashFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PendingHashFunction, string>(pendingHashFunction, blockParameter);
        }


        public Task<string> PendingHashQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PendingHashFunction, string>(null, blockParameter);
        }

        public Task<byte> IndexCategoryQueryAsync(IndexCategoryFunction indexCategoryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IndexCategoryFunction, byte>(indexCategoryFunction, blockParameter);
        }


        public Task<byte> IndexCategoryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IndexCategoryFunction, byte>(null, blockParameter);
        }

        public Task<string> GetPendingApprovalRequestQueryAsync(GetPendingApprovalRequestFunction getPendingApprovalRequestFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPendingApprovalRequestFunction, string>(getPendingApprovalRequestFunction, blockParameter);
        }


        public Task<string> GetPendingApprovalRequestQueryAsync(BigInteger index, BlockParameter blockParameter = null)
        {
            var getPendingApprovalRequestFunction = new GetPendingApprovalRequestFunction();
            getPendingApprovalRequestFunction.Index = index;

            return ContractHandler.QueryAsync<GetPendingApprovalRequestFunction, string>(getPendingApprovalRequestFunction, blockParameter);
        }

        public Task<string> AddContributorGroupRequestAsync(AddContributorGroupFunction addContributorGroupFunction)
        {
            return ContractHandler.SendRequestAsync(addContributorGroupFunction);
        }

        public Task<TransactionReceipt> AddContributorGroupRequestAndWaitForReceiptAsync(AddContributorGroupFunction addContributorGroupFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(addContributorGroupFunction, cancellationToken);
        }

        public Task<string> AddContributorGroupRequestAsync(string group)
        {
            var addContributorGroupFunction = new AddContributorGroupFunction();
            addContributorGroupFunction.Group = group;

            return ContractHandler.SendRequestAsync(addContributorGroupFunction);
        }

        public Task<TransactionReceipt> AddContributorGroupRequestAndWaitForReceiptAsync(string group, CancellationTokenSource cancellationToken = null)
        {
            var addContributorGroupFunction = new AddContributorGroupFunction();
            addContributorGroupFunction.Group = group;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(addContributorGroupFunction, cancellationToken);
        }

        public Task<bool> HasEditorRightQueryAsync(HasEditorRightFunction hasEditorRightFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasEditorRightFunction, bool>(hasEditorRightFunction, blockParameter);
        }


        public Task<bool> HasEditorRightQueryAsync(string candidate, BlockParameter blockParameter = null)
        {
            var hasEditorRightFunction = new HasEditorRightFunction();
            hasEditorRightFunction.Candidate = candidate;

            return ContractHandler.QueryAsync<HasEditorRightFunction, bool>(hasEditorRightFunction, blockParameter);
        }

        public Task<string> TransferCreatorshipRequestAsync(TransferCreatorshipFunction transferCreatorshipFunction)
        {
            return ContractHandler.SendRequestAsync(transferCreatorshipFunction);
        }

        public Task<TransactionReceipt> TransferCreatorshipRequestAndWaitForReceiptAsync(TransferCreatorshipFunction transferCreatorshipFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(transferCreatorshipFunction, cancellationToken);
        }

        public Task<string> TransferCreatorshipRequestAsync(string newCreator)
        {
            var transferCreatorshipFunction = new TransferCreatorshipFunction();
            transferCreatorshipFunction.NewCreator = newCreator;

            return ContractHandler.SendRequestAsync(transferCreatorshipFunction);
        }

        public Task<TransactionReceipt> TransferCreatorshipRequestAndWaitForReceiptAsync(string newCreator, CancellationTokenSource cancellationToken = null)
        {
            var transferCreatorshipFunction = new TransferCreatorshipFunction();
            transferCreatorshipFunction.NewCreator = newCreator;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(transferCreatorshipFunction, cancellationToken);
        }

        public Task<bool> CanCommitQueryAsync(CanCommitFunction canCommitFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanCommitFunction, bool>(canCommitFunction, blockParameter);
        }


        public Task<bool> CanCommitQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanCommitFunction, bool>(null, blockParameter);
        }

        public Task<BigInteger> VersionTimestampQueryAsync(VersionTimestampFunction versionTimestampFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VersionTimestampFunction, BigInteger>(versionTimestampFunction, blockParameter);
        }


        public Task<BigInteger> VersionTimestampQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var versionTimestampFunction = new VersionTimestampFunction();
            versionTimestampFunction.ReturnValue1 = returnValue1;

            return ContractHandler.QueryAsync<VersionTimestampFunction, BigInteger>(versionTimestampFunction, blockParameter);
        }

        public Task<string> VersionHashesQueryAsync(VersionHashesFunction versionHashesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VersionHashesFunction, string>(versionHashesFunction, blockParameter);
        }


        public Task<string> VersionHashesQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var versionHashesFunction = new VersionHashesFunction();
            versionHashesFunction.ReturnValue1 = returnValue1;

            return ContractHandler.QueryAsync<VersionHashesFunction, string>(versionHashesFunction, blockParameter);
        }

        public Task<bool> CanEditQueryAsync(CanEditFunction canEditFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanEditFunction, bool>(canEditFunction, blockParameter);
        }


        public Task<bool> CanEditQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanEditFunction, bool>(null, blockParameter);
        }

        public Task<string> ApproveContentRequestAsync(ApproveContentFunction approveContentFunction)
        {
            return ContractHandler.SendRequestAsync(approveContentFunction);
        }

        public Task<TransactionReceipt> ApproveContentRequestAndWaitForReceiptAsync(ApproveContentFunction approveContentFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(approveContentFunction, cancellationToken);
        }

        public Task<string> ApproveContentRequestAsync(string contentContract, bool approved, string note)
        {
            var approveContentFunction = new ApproveContentFunction();
            approveContentFunction.ContentContract = contentContract;
            approveContentFunction.Approved = approved;
            approveContentFunction.Note = note;

            return ContractHandler.SendRequestAsync(approveContentFunction);
        }

        public Task<TransactionReceipt> ApproveContentRequestAndWaitForReceiptAsync(string contentContract, bool approved, string note, CancellationTokenSource cancellationToken = null)
        {
            var approveContentFunction = new ApproveContentFunction();
            approveContentFunction.ContentContract = contentContract;
            approveContentFunction.Approved = approved;
            approveContentFunction.Note = note;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(approveContentFunction, cancellationToken);
        }

        public Task<string> DeleteContentRequestAsync(DeleteContentFunction deleteContentFunction)
        {
            return ContractHandler.SendRequestAsync(deleteContentFunction);
        }

        public Task<TransactionReceipt> DeleteContentRequestAndWaitForReceiptAsync(DeleteContentFunction deleteContentFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(deleteContentFunction, cancellationToken);
        }

        public Task<string> DeleteContentRequestAsync(string contentAddr)
        {
            var deleteContentFunction = new DeleteContentFunction();
            deleteContentFunction.ContentAddr = contentAddr;

            return ContractHandler.SendRequestAsync(deleteContentFunction);
        }

        public Task<TransactionReceipt> DeleteContentRequestAndWaitForReceiptAsync(string contentAddr, CancellationTokenSource cancellationToken = null)
        {
            var deleteContentFunction = new DeleteContentFunction();
            deleteContentFunction.ContentAddr = contentAddr;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(deleteContentFunction, cancellationToken);
        }

        public Task<string> ApprovalRequestsQueryAsync(ApprovalRequestsFunction approvalRequestsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ApprovalRequestsFunction, string>(approvalRequestsFunction, blockParameter);
        }


        public Task<string> ApprovalRequestsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var approvalRequestsFunction = new ApprovalRequestsFunction();
            approvalRequestsFunction.ReturnValue1 = returnValue1;

            return ContractHandler.QueryAsync<ApprovalRequestsFunction, string>(approvalRequestsFunction, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }


        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> ReviewerGroupsQueryAsync(ReviewerGroupsFunction reviewerGroupsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReviewerGroupsFunction, string>(reviewerGroupsFunction, blockParameter);
        }


        public Task<string> ReviewerGroupsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var reviewerGroupsFunction = new ReviewerGroupsFunction();
            reviewerGroupsFunction.ReturnValue1 = returnValue1;

            return ContractHandler.QueryAsync<ReviewerGroupsFunction, string>(reviewerGroupsFunction, blockParameter);
        }

        public Task<bool> HasAccessQueryAsync(HasAccessFunction hasAccessFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasAccessFunction, bool>(hasAccessFunction, blockParameter);
        }


        public Task<bool> HasAccessQueryAsync(string candidate, BlockParameter blockParameter = null)
        {
            var hasAccessFunction = new HasAccessFunction();
            hasAccessFunction.Candidate = candidate;

            return ContractHandler.QueryAsync<HasAccessFunction, bool>(hasAccessFunction, blockParameter);
        }

        public Task<byte> CanAccessQueryAsync(CanAccessFunction canAccessFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanAccessFunction, byte>(canAccessFunction, blockParameter);
        }


        public Task<byte> CanAccessQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanAccessFunction, byte>(null, blockParameter);
        }

        public Task<string> CommitRequestAsync(CommitFunction commitFunction)
        {
            return ContractHandler.SendRequestAsync(commitFunction);
        }

        public Task<TransactionReceipt> CommitRequestAndWaitForReceiptAsync(CommitFunction commitFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(commitFunction, cancellationToken);
        }

        public Task<string> CommitRequestAsync(string objectHash)
        {
            var commitFunction = new CommitFunction();
            commitFunction.ObjectHash = objectHash;

            return ContractHandler.SendRequestAsync(commitFunction);
        }

        public Task<TransactionReceipt> CommitRequestAndWaitForReceiptAsync(string objectHash, CancellationTokenSource cancellationToken = null)
        {
            var commitFunction = new CommitFunction();
            commitFunction.ObjectHash = objectHash;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(commitFunction, cancellationToken);
        }

        public Task<string> ContentTypesQueryAsync(ContentTypesFunction contentTypesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContentTypesFunction, string>(contentTypesFunction, blockParameter);
        }


        public Task<string> ContentTypesQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var contentTypesFunction = new ContentTypesFunction();
            contentTypesFunction.ReturnValue1 = returnValue1;

            return ContractHandler.QueryAsync<ContentTypesFunction, string>(contentTypesFunction, blockParameter);
        }

        public Task<bool> CanPublishQueryAsync(CanPublish1Function canPublish1Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanPublish1Function, bool>(canPublish1Function, blockParameter);
        }


        public Task<bool> CanPublishQueryAsync(string candidate, BlockParameter blockParameter = null)
        {
            var canPublish1Function = new CanPublish1Function();
            canPublish1Function.Candidate = candidate;

            return ContractHandler.QueryAsync<CanPublish1Function, bool>(canPublish1Function, blockParameter);
        }

        public Task<bool> WhitelistedTypeQueryAsync(WhitelistedTypeFunction whitelistedTypeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WhitelistedTypeFunction, bool>(whitelistedTypeFunction, blockParameter);
        }


        public Task<bool> WhitelistedTypeQueryAsync(string contentType, BlockParameter blockParameter = null)
        {
            var whitelistedTypeFunction = new WhitelistedTypeFunction();
            whitelistedTypeFunction.ContentType = contentType;

            return ContractHandler.QueryAsync<WhitelistedTypeFunction, bool>(whitelistedTypeFunction, blockParameter);
        }

        public Task<string> SetVisibilityRequestAsync(SetVisibilityFunction setVisibilityFunction)
        {
            return ContractHandler.SendRequestAsync(setVisibilityFunction);
        }

        public Task<TransactionReceipt> SetVisibilityRequestAndWaitForReceiptAsync(SetVisibilityFunction setVisibilityFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(setVisibilityFunction, cancellationToken);
        }

        public Task<string> SetVisibilityRequestAsync(byte visibilityCode)
        {
            var setVisibilityFunction = new SetVisibilityFunction();
            setVisibilityFunction.VisibilityCode = visibilityCode;

            return ContractHandler.SendRequestAsync(setVisibilityFunction);
        }

        public Task<TransactionReceipt> SetVisibilityRequestAndWaitForReceiptAsync(byte visibilityCode, CancellationTokenSource cancellationToken = null)
        {
            var setVisibilityFunction = new SetVisibilityFunction();
            setVisibilityFunction.VisibilityCode = visibilityCode;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(setVisibilityFunction, cancellationToken);
        }

        public Task<byte[]> GetMetaQueryAsync(GetMetaFunction getMetaFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetMetaFunction, byte[]>(getMetaFunction, blockParameter);
        }


        public Task<byte[]> GetMetaQueryAsync(byte[] key, BlockParameter blockParameter = null)
        {
            var getMetaFunction = new GetMetaFunction();
            getMetaFunction.Key = key;

            return ContractHandler.QueryAsync<GetMetaFunction, byte[]>(getMetaFunction, blockParameter);
        }

        public Task<string> ContentSpaceQueryAsync(ContentSpaceFunction contentSpaceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContentSpaceFunction, string>(contentSpaceFunction, blockParameter);
        }


        public Task<string> ContentSpaceQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContentSpaceFunction, string>(null, blockParameter);
        }

        public Task<string> UpdateRequestRequestAsync(UpdateRequestFunction updateRequestFunction)
        {
            return ContractHandler.SendRequestAsync(updateRequestFunction);
        }

        public Task<string> UpdateRequestRequestAsync()
        {
            return ContractHandler.SendRequestAsync<UpdateRequestFunction>();
        }

        public Task<TransactionReceipt> UpdateRequestRequestAndWaitForReceiptAsync(UpdateRequestFunction updateRequestFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(updateRequestFunction, cancellationToken);
        }

        public Task<TransactionReceipt> UpdateRequestRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync<UpdateRequestFunction>(null, cancellationToken);
        }

        public Task<BigInteger> ContentTypesLengthQueryAsync(ContentTypesLengthFunction contentTypesLengthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContentTypesLengthFunction, BigInteger>(contentTypesLengthFunction, blockParameter);
        }


        public Task<BigInteger> ContentTypesLengthQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContentTypesLengthFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> SetAddressKMSRequestAsync(SetAddressKMSFunction setAddressKMSFunction)
        {
            return ContractHandler.SendRequestAsync(setAddressKMSFunction);
        }

        public Task<TransactionReceipt> SetAddressKMSRequestAndWaitForReceiptAsync(SetAddressKMSFunction setAddressKMSFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(setAddressKMSFunction, cancellationToken);
        }

        public Task<string> SetAddressKMSRequestAsync(string addressKms)
        {
            var setAddressKMSFunction = new SetAddressKMSFunction();
            setAddressKMSFunction.AddressKms = addressKms;

            return ContractHandler.SendRequestAsync(setAddressKMSFunction);
        }

        public Task<TransactionReceipt> SetAddressKMSRequestAndWaitForReceiptAsync(string addressKms, CancellationTokenSource cancellationToken = null)
        {
            var setAddressKMSFunction = new SetAddressKMSFunction();
            setAddressKMSFunction.AddressKms = addressKms;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(setAddressKMSFunction, cancellationToken);
        }

        public Task<bool> CanPublishQueryAsync(CanPublishFunction canPublishFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanPublishFunction, bool>(canPublishFunction, blockParameter);
        }


        public Task<bool> CanPublishQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanPublishFunction, bool>(null, blockParameter);
        }

        public Task<string> AddReviewerGroupRequestAsync(AddReviewerGroupFunction addReviewerGroupFunction)
        {
            return ContractHandler.SendRequestAsync(addReviewerGroupFunction);
        }

        public Task<TransactionReceipt> AddReviewerGroupRequestAndWaitForReceiptAsync(AddReviewerGroupFunction addReviewerGroupFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(addReviewerGroupFunction, cancellationToken);
        }

        public Task<string> AddReviewerGroupRequestAsync(string group)
        {
            var addReviewerGroupFunction = new AddReviewerGroupFunction();
            addReviewerGroupFunction.Group = group;

            return ContractHandler.SendRequestAsync(addReviewerGroupFunction);
        }

        public Task<TransactionReceipt> AddReviewerGroupRequestAndWaitForReceiptAsync(string group, CancellationTokenSource cancellationToken = null)
        {
            var addReviewerGroupFunction = new AddReviewerGroupFunction();
            addReviewerGroupFunction.Group = group;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(addReviewerGroupFunction, cancellationToken);
        }

        public Task<string> ObjectHashQueryAsync(ObjectHashFunction objectHashFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ObjectHashFunction, string>(objectHashFunction, blockParameter);
        }


        public Task<string> ObjectHashQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ObjectHashFunction, string>(null, blockParameter);
        }

        public Task<string> DeleteVersionRequestAsync(DeleteVersionFunction deleteVersionFunction)
        {
            return ContractHandler.SendRequestAsync(deleteVersionFunction);
        }

        public Task<TransactionReceipt> DeleteVersionRequestAndWaitForReceiptAsync(DeleteVersionFunction deleteVersionFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(deleteVersionFunction, cancellationToken);
        }

        public Task<string> DeleteVersionRequestAsync(string versionHash)
        {
            var deleteVersionFunction = new DeleteVersionFunction();
            deleteVersionFunction.VersionHash = versionHash;

            return ContractHandler.SendRequestAsync(deleteVersionFunction);
        }

        public Task<TransactionReceipt> DeleteVersionRequestAndWaitForReceiptAsync(string versionHash, CancellationTokenSource cancellationToken = null)
        {
            var deleteVersionFunction = new DeleteVersionFunction();
            deleteVersionFunction.VersionHash = versionHash;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(deleteVersionFunction, cancellationToken);
        }

        public Task<string> PutMetaRequestAsync(PutMetaFunction putMetaFunction)
        {
            return ContractHandler.SendRequestAsync(putMetaFunction);
        }

        public Task<TransactionReceipt> PutMetaRequestAndWaitForReceiptAsync(PutMetaFunction putMetaFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(putMetaFunction, cancellationToken);
        }

        public Task<string> PutMetaRequestAsync(byte[] key, byte[] value)
        {
            var putMetaFunction = new PutMetaFunction();
            putMetaFunction.Key = key;
            putMetaFunction.Value = value;

            return ContractHandler.SendRequestAsync(putMetaFunction);
        }

        public Task<TransactionReceipt> PutMetaRequestAndWaitForReceiptAsync(byte[] key, byte[] value, CancellationTokenSource cancellationToken = null)
        {
            var putMetaFunction = new PutMetaFunction();
            putMetaFunction.Key = key;
            putMetaFunction.Value = value;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(putMetaFunction, cancellationToken);
        }

        public Task<BigInteger> AccessorGroupsLengthQueryAsync(AccessorGroupsLengthFunction accessorGroupsLengthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AccessorGroupsLengthFunction, BigInteger>(accessorGroupsLengthFunction, blockParameter);
        }


        public Task<BigInteger> AccessorGroupsLengthQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AccessorGroupsLengthFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> RemoveAccessorGroupRequestAsync(RemoveAccessorGroupFunction removeAccessorGroupFunction)
        {
            return ContractHandler.SendRequestAsync(removeAccessorGroupFunction);
        }

        public Task<TransactionReceipt> RemoveAccessorGroupRequestAndWaitForReceiptAsync(RemoveAccessorGroupFunction removeAccessorGroupFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(removeAccessorGroupFunction, cancellationToken);
        }

        public Task<string> RemoveAccessorGroupRequestAsync(string group)
        {
            var removeAccessorGroupFunction = new RemoveAccessorGroupFunction();
            removeAccessorGroupFunction.Group = group;

            return ContractHandler.SendRequestAsync(removeAccessorGroupFunction);
        }

        public Task<TransactionReceipt> RemoveAccessorGroupRequestAndWaitForReceiptAsync(string group, CancellationTokenSource cancellationToken = null)
        {
            var removeAccessorGroupFunction = new RemoveAccessorGroupFunction();
            removeAccessorGroupFunction.Group = group;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(removeAccessorGroupFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(TransferOwnershipFunction transferOwnershipFunction)
        {
            return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(TransferOwnershipFunction transferOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(string newOwner)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
            transferOwnershipFunction.NewOwner = newOwner;

            return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(string newOwner, CancellationTokenSource cancellationToken = null)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
            transferOwnershipFunction.NewOwner = newOwner;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> RemoveContentTypeRequestAsync(RemoveContentTypeFunction removeContentTypeFunction)
        {
            return ContractHandler.SendRequestAsync(removeContentTypeFunction);
        }

        public Task<TransactionReceipt> RemoveContentTypeRequestAndWaitForReceiptAsync(RemoveContentTypeFunction removeContentTypeFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(removeContentTypeFunction, cancellationToken);
        }

        public Task<string> RemoveContentTypeRequestAsync(string contentType)
        {
            var removeContentTypeFunction = new RemoveContentTypeFunction();
            removeContentTypeFunction.ContentType = contentType;

            return ContractHandler.SendRequestAsync(removeContentTypeFunction);
        }

        public Task<TransactionReceipt> RemoveContentTypeRequestAndWaitForReceiptAsync(string contentType, CancellationTokenSource cancellationToken = null)
        {
            var removeContentTypeFunction = new RemoveContentTypeFunction();
            removeContentTypeFunction.ContentType = contentType;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(removeContentTypeFunction, cancellationToken);
        }
    }
}
