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
using Elv.NET.Contracts.BaseContentType.ContractDefinition;

namespace Elv.NET.Contracts.BaseContentType
{
    public partial class BaseContentTypeService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, BaseContentTypeDeployment baseContentTypeDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<BaseContentTypeDeployment>().SendRequestAndWaitForReceiptAsync(baseContentTypeDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, BaseContentTypeDeployment baseContentTypeDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<BaseContentTypeDeployment>().SendRequestAsync(baseContentTypeDeployment);
        }

        public static async Task<BaseContentTypeService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, BaseContentTypeDeployment baseContentTypeDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, baseContentTypeDeployment, cancellationTokenSource);
            return new BaseContentTypeService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3 { get; }

        public ContractHandler ContractHandler { get; }

        public BaseContentTypeService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public BaseContentTypeService(Nethereum.Web3.IWeb3 web3, string contractAddress)
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

        public Task<string> CreatorQueryAsync(CreatorFunction creatorFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CreatorFunction, string>(creatorFunction, blockParameter);
        }


        public Task<string> CreatorQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CreatorFunction, string>(null, blockParameter);
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

        public Task<byte> VisibilityQueryAsync(VisibilityFunction visibilityFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VisibilityFunction, byte>(visibilityFunction, blockParameter);
        }


        public Task<byte> VisibilityQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VisibilityFunction, byte>(null, blockParameter);
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

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }


        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
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
    }
}
