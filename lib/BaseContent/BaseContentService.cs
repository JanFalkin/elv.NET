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
using NethereumSample.BaseContent.ContractDefinition;

namespace NethereumSample.BaseContent
{
    public partial class BaseContentService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, BaseContentDeployment baseContentDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<BaseContentDeployment>().SendRequestAndWaitForReceiptAsync(baseContentDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, BaseContentDeployment baseContentDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<BaseContentDeployment>().SendRequestAsync(baseContentDeployment);
        }

        public static async Task<BaseContentService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, BaseContentDeployment baseContentDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, baseContentDeployment, cancellationTokenSource);
            return new BaseContentService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3 { get; }

        public ContractHandler ContractHandler { get; }

        public BaseContentService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public BaseContentService(Nethereum.Web3.IWeb3 web3, string contractAddress)
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

        public Task<string> AccessCompleteRequestAsync(AccessCompleteFunction accessCompleteFunction)
        {
            return ContractHandler.SendRequestAsync(accessCompleteFunction);
        }

        public Task<TransactionReceipt> AccessCompleteRequestAndWaitForReceiptAsync(AccessCompleteFunction accessCompleteFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(accessCompleteFunction, cancellationToken);
        }

        public Task<string> AccessCompleteRequestAsync(BigInteger requestId, BigInteger scorePct, BigInteger returnValue3)
        {
            var accessCompleteFunction = new AccessCompleteFunction();
            accessCompleteFunction.RequestId = requestId;
            accessCompleteFunction.ScorePct = scorePct;
            accessCompleteFunction.ReturnValue3 = returnValue3;

            return ContractHandler.SendRequestAsync(accessCompleteFunction);
        }

        public Task<TransactionReceipt> AccessCompleteRequestAndWaitForReceiptAsync(BigInteger requestId, BigInteger scorePct, BigInteger returnValue3, CancellationTokenSource cancellationToken = null)
        {
            var accessCompleteFunction = new AccessCompleteFunction();
            accessCompleteFunction.RequestId = requestId;
            accessCompleteFunction.ScorePct = scorePct;
            accessCompleteFunction.ReturnValue3 = returnValue3;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(accessCompleteFunction, cancellationToken);
        }

        public Task<string> PublishRequestAsync(PublishFunction publishFunction)
        {
            return ContractHandler.SendRequestAsync(publishFunction);
        }

        public Task<string> PublishRequestAsync()
        {
            return ContractHandler.SendRequestAsync<PublishFunction>();
        }

        public Task<TransactionReceipt> PublishRequestAndWaitForReceiptAsync(PublishFunction publishFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(publishFunction, cancellationToken);
        }

        public Task<TransactionReceipt> PublishRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync<PublishFunction>(null, cancellationToken);
        }

        public Task<string> ProcessRequestPaymentRequestAsync(ProcessRequestPaymentFunction processRequestPaymentFunction)
        {
            return ContractHandler.SendRequestAsync(processRequestPaymentFunction);
        }

        public Task<TransactionReceipt> ProcessRequestPaymentRequestAndWaitForReceiptAsync(ProcessRequestPaymentFunction processRequestPaymentFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(processRequestPaymentFunction, cancellationToken);
        }

        public Task<string> ProcessRequestPaymentRequestAsync(BigInteger requestNonce, string payee, string label, BigInteger amount)
        {
            var processRequestPaymentFunction = new ProcessRequestPaymentFunction();
            processRequestPaymentFunction.RequestNonce = requestNonce;
            processRequestPaymentFunction.Payee = payee;
            processRequestPaymentFunction.Label = label;
            processRequestPaymentFunction.Amount = amount;

            return ContractHandler.SendRequestAsync(processRequestPaymentFunction);
        }

        public Task<TransactionReceipt> ProcessRequestPaymentRequestAndWaitForReceiptAsync(BigInteger requestNonce, string payee, string label, BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var processRequestPaymentFunction = new ProcessRequestPaymentFunction();
            processRequestPaymentFunction.RequestNonce = requestNonce;
            processRequestPaymentFunction.Payee = payee;
            processRequestPaymentFunction.Label = label;
            processRequestPaymentFunction.Amount = amount;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(processRequestPaymentFunction, cancellationToken);
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

        public Task<RequestMapOutputDTO> RequestMapQueryAsync(RequestMapFunction requestMapFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<RequestMapFunction, RequestMapOutputDTO>(requestMapFunction, blockParameter);
        }

        public Task<RequestMapOutputDTO> RequestMapQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var requestMapFunction = new RequestMapFunction();
            requestMapFunction.ReturnValue1 = returnValue1;

            return ContractHandler.QueryDeserializingToObjectAsync<RequestMapFunction, RequestMapOutputDTO>(requestMapFunction, blockParameter);
        }

        public Task<string> AccessRequestV3RequestAsync(AccessRequestV3Function accessRequestV3Function)
        {
            return ContractHandler.SendRequestAsync(accessRequestV3Function);
        }

        public Task<TransactionReceipt> AccessRequestV3RequestAndWaitForReceiptAsync(AccessRequestV3Function accessRequestV3Function, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(accessRequestV3Function, cancellationToken);
        }

        public Task<string> AccessRequestV3RequestAsync(List<byte[]> customValues, List<string> stakeholders)
        {
            var accessRequestV3Function = new AccessRequestV3Function();
            accessRequestV3Function.CustomValues = customValues;
            accessRequestV3Function.Stakeholders = stakeholders;

            return ContractHandler.SendRequestAsync(accessRequestV3Function);
        }

        public Task<TransactionReceipt> AccessRequestV3RequestAndWaitForReceiptAsync(List<byte[]> customValues, List<string> stakeholders, CancellationTokenSource cancellationToken = null)
        {
            var accessRequestV3Function = new AccessRequestV3Function();
            accessRequestV3Function.CustomValues = customValues;
            accessRequestV3Function.Stakeholders = stakeholders;

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

        public Task<string> ContentContractAddressQueryAsync(ContentContractAddressFunction contentContractAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContentContractAddressFunction, string>(contentContractAddressFunction, blockParameter);
        }


        public Task<string> ContentContractAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContentContractAddressFunction, string>(null, blockParameter);
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

        public Task<BigInteger> StatusCodeQueryAsync(StatusCodeFunction statusCodeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StatusCodeFunction, BigInteger>(statusCodeFunction, blockParameter);
        }


        public Task<BigInteger> StatusCodeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StatusCodeFunction, BigInteger>(null, blockParameter);
        }

        public Task<byte> VisibilityQueryAsync(VisibilityFunction visibilityFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VisibilityFunction, byte>(visibilityFunction, blockParameter);
        }


        public Task<byte> VisibilityQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VisibilityFunction, byte>(null, blockParameter);
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

        public Task<string> ContentTypeQueryAsync(ContentTypeFunction contentTypeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContentTypeFunction, string>(contentTypeFunction, blockParameter);
        }


        public Task<string> ContentTypeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContentTypeFunction, string>(null, blockParameter);
        }

        public Task<bool> CommitPendingQueryAsync(CommitPendingFunction commitPendingFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CommitPendingFunction, bool>(commitPendingFunction, blockParameter);
        }


        public Task<bool> CommitPendingQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CommitPendingFunction, bool>(null, blockParameter);
        }

        public Task<GetAccessInfoOutputDTO> GetAccessInfoQueryAsync(GetAccessInfoFunction getAccessInfoFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAccessInfoFunction, GetAccessInfoOutputDTO>(getAccessInfoFunction, blockParameter);
        }

        public Task<GetAccessInfoOutputDTO> GetAccessInfoQueryAsync(byte returnValue1, List<byte[]> customValues, List<string> stakeholders, BlockParameter blockParameter = null)
        {
            var getAccessInfoFunction = new GetAccessInfoFunction();
            getAccessInfoFunction.ReturnValue1 = returnValue1;
            getAccessInfoFunction.CustomValues = customValues;
            getAccessInfoFunction.Stakeholders = stakeholders;

            return ContractHandler.QueryDeserializingToObjectAsync<GetAccessInfoFunction, GetAccessInfoOutputDTO>(getAccessInfoFunction, blockParameter);
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

        public Task<string> AccessCompleteV3RequestAsync(AccessCompleteV3Function accessCompleteV3Function)
        {
            return ContractHandler.SendRequestAsync(accessCompleteV3Function);
        }

        public Task<TransactionReceipt> AccessCompleteV3RequestAndWaitForReceiptAsync(AccessCompleteV3Function accessCompleteV3Function, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(accessCompleteV3Function, cancellationToken);
        }

        public Task<string> AccessCompleteV3RequestAsync(BigInteger requestNonce, List<byte[]> customValues, List<string> stakeholders)
        {
            var accessCompleteV3Function = new AccessCompleteV3Function();
            accessCompleteV3Function.RequestNonce = requestNonce;
            accessCompleteV3Function.CustomValues = customValues;
            accessCompleteV3Function.Stakeholders = stakeholders;

            return ContractHandler.SendRequestAsync(accessCompleteV3Function);
        }

        public Task<TransactionReceipt> AccessCompleteV3RequestAndWaitForReceiptAsync(BigInteger requestNonce, List<byte[]> customValues, List<string> stakeholders, CancellationTokenSource cancellationToken = null)
        {
            var accessCompleteV3Function = new AccessCompleteV3Function();
            accessCompleteV3Function.RequestNonce = requestNonce;
            accessCompleteV3Function.CustomValues = customValues;
            accessCompleteV3Function.Stakeholders = stakeholders;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(accessCompleteV3Function, cancellationToken);
        }

        public Task<string> AccessCompleteInternalRequestAsync(AccessCompleteInternalFunction accessCompleteInternalFunction)
        {
            return ContractHandler.SendRequestAsync(accessCompleteInternalFunction);
        }

        public Task<TransactionReceipt> AccessCompleteInternalRequestAndWaitForReceiptAsync(AccessCompleteInternalFunction accessCompleteInternalFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(accessCompleteInternalFunction, cancellationToken);
        }

        public Task<string> AccessCompleteInternalRequestAsync(BigInteger requestNonce, List<byte[]> customValues, List<string> stakeholders)
        {
            var accessCompleteInternalFunction = new AccessCompleteInternalFunction();
            accessCompleteInternalFunction.RequestNonce = requestNonce;
            accessCompleteInternalFunction.CustomValues = customValues;
            accessCompleteInternalFunction.Stakeholders = stakeholders;

            return ContractHandler.SendRequestAsync(accessCompleteInternalFunction);
        }

        public Task<TransactionReceipt> AccessCompleteInternalRequestAndWaitForReceiptAsync(BigInteger requestNonce, List<byte[]> customValues, List<string> stakeholders, CancellationTokenSource cancellationToken = null)
        {
            var accessCompleteInternalFunction = new AccessCompleteInternalFunction();
            accessCompleteInternalFunction.RequestNonce = requestNonce;
            accessCompleteInternalFunction.CustomValues = customValues;
            accessCompleteInternalFunction.Stakeholders = stakeholders;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(accessCompleteInternalFunction, cancellationToken);
        }

        public Task<string> SetStatusCodeRequestAsync(SetStatusCodeFunction setStatusCodeFunction)
        {
            return ContractHandler.SendRequestAsync(setStatusCodeFunction);
        }

        public Task<TransactionReceipt> SetStatusCodeRequestAndWaitForReceiptAsync(SetStatusCodeFunction setStatusCodeFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(setStatusCodeFunction, cancellationToken);
        }

        public Task<string> SetStatusCodeRequestAsync(BigInteger statusCode)
        {
            var setStatusCodeFunction = new SetStatusCodeFunction();
            setStatusCodeFunction.StatusCode = statusCode;

            return ContractHandler.SendRequestAsync(setStatusCodeFunction);
        }

        public Task<TransactionReceipt> SetStatusCodeRequestAndWaitForReceiptAsync(BigInteger statusCode, CancellationTokenSource cancellationToken = null)
        {
            var setStatusCodeFunction = new SetStatusCodeFunction();
            setStatusCodeFunction.StatusCode = statusCode;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(setStatusCodeFunction, cancellationToken);
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

        public Task<BigInteger> AccessChargeQueryAsync(AccessChargeFunction accessChargeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AccessChargeFunction, BigInteger>(accessChargeFunction, blockParameter);
        }


        public Task<BigInteger> AccessChargeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AccessChargeFunction, BigInteger>(null, blockParameter);
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

        public Task<string> AccessRequestContextRequestAsync(AccessRequestContextFunction accessRequestContextFunction)
        {
            return ContractHandler.SendRequestAsync(accessRequestContextFunction);
        }

        public Task<TransactionReceipt> AccessRequestContextRequestAndWaitForReceiptAsync(AccessRequestContextFunction accessRequestContextFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(accessRequestContextFunction, cancellationToken);
        }

        public Task<string> AccessRequestContextRequestAsync(BigInteger requestNonce, byte[] contextHash, string accessor, BigInteger requestTimestamp)
        {
            var accessRequestContextFunction = new AccessRequestContextFunction();
            accessRequestContextFunction.RequestNonce = requestNonce;
            accessRequestContextFunction.ContextHash = contextHash;
            accessRequestContextFunction.Accessor = accessor;
            accessRequestContextFunction.RequestTimestamp = requestTimestamp;

            return ContractHandler.SendRequestAsync(accessRequestContextFunction);
        }

        public Task<TransactionReceipt> AccessRequestContextRequestAndWaitForReceiptAsync(BigInteger requestNonce, byte[] contextHash, string accessor, BigInteger requestTimestamp, CancellationTokenSource cancellationToken = null)
        {
            var accessRequestContextFunction = new AccessRequestContextFunction();
            accessRequestContextFunction.RequestNonce = requestNonce;
            accessRequestContextFunction.ContextHash = contextHash;
            accessRequestContextFunction.Accessor = accessor;
            accessRequestContextFunction.RequestTimestamp = requestTimestamp;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(accessRequestContextFunction, cancellationToken);
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

        public Task<GetAccessInfoV3OutputDTO> GetAccessInfoV3QueryAsync(GetAccessInfoV3Function getAccessInfoV3Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetAccessInfoV3Function, GetAccessInfoV3OutputDTO>(getAccessInfoV3Function, blockParameter);
        }

        public Task<GetAccessInfoV3OutputDTO> GetAccessInfoV3QueryAsync(string accessor, List<byte[]> customValues, List<string> stakeholders, BlockParameter blockParameter = null)
        {
            var getAccessInfoV3Function = new GetAccessInfoV3Function();
            getAccessInfoV3Function.Accessor = accessor;
            getAccessInfoV3Function.CustomValues = customValues;
            getAccessInfoV3Function.Stakeholders = stakeholders;

            return ContractHandler.QueryDeserializingToObjectAsync<GetAccessInfoV3Function, GetAccessInfoV3OutputDTO>(getAccessInfoV3Function, blockParameter);
        }

        public Task<bool> CanEditQueryAsync(CanEditFunction canEditFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanEditFunction, bool>(canEditFunction, blockParameter);
        }


        public Task<bool> CanEditQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanEditFunction, bool>(null, blockParameter);
        }

        public Task<string> UpdateStatusRequestAsync(UpdateStatusFunction updateStatusFunction)
        {
            return ContractHandler.SendRequestAsync(updateStatusFunction);
        }

        public Task<TransactionReceipt> UpdateStatusRequestAndWaitForReceiptAsync(UpdateStatusFunction updateStatusFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(updateStatusFunction, cancellationToken);
        }

        public Task<string> UpdateStatusRequestAsync(BigInteger statusCode)
        {
            var updateStatusFunction = new UpdateStatusFunction();
            updateStatusFunction.StatusCode = statusCode;

            return ContractHandler.SendRequestAsync(updateStatusFunction);
        }

        public Task<TransactionReceipt> UpdateStatusRequestAndWaitForReceiptAsync(BigInteger statusCode, CancellationTokenSource cancellationToken = null)
        {
            var updateStatusFunction = new UpdateStatusFunction();
            updateStatusFunction.StatusCode = statusCode;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(updateStatusFunction, cancellationToken);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }


        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> RequestIDQueryAsync(RequestIDFunction requestIDFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RequestIDFunction, BigInteger>(requestIDFunction, blockParameter);
        }


        public Task<BigInteger> RequestIDQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RequestIDFunction, BigInteger>(null, blockParameter);
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

        public Task<string> AccessRequestRequestAsync(AccessRequestFunction accessRequestFunction)
        {
            return ContractHandler.SendRequestAsync(accessRequestFunction);
        }

        public Task<TransactionReceipt> AccessRequestRequestAndWaitForReceiptAsync(AccessRequestFunction accessRequestFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(accessRequestFunction, cancellationToken);
        }

        public Task<string> AccessRequestRequestAsync(byte returnValue1, string pkeRequestor, string pkeAFGH, List<byte[]> customValues, List<string> stakeholders)
        {
            var accessRequestFunction = new AccessRequestFunction();
            accessRequestFunction.ReturnValue1 = returnValue1;
            accessRequestFunction.PkeRequestor = pkeRequestor;
            accessRequestFunction.PkeAFGH = pkeAFGH;
            accessRequestFunction.CustomValues = customValues;
            accessRequestFunction.Stakeholders = stakeholders;

            return ContractHandler.SendRequestAsync(accessRequestFunction);
        }

        public Task<TransactionReceipt> AccessRequestRequestAndWaitForReceiptAsync(byte returnValue1, string pkeRequestor, string pkeAFGH, List<byte[]> customValues, List<string> stakeholders, CancellationTokenSource cancellationToken = null)
        {
            var accessRequestFunction = new AccessRequestFunction();
            accessRequestFunction.ReturnValue1 = returnValue1;
            accessRequestFunction.PkeRequestor = pkeRequestor;
            accessRequestFunction.PkeAFGH = pkeAFGH;
            accessRequestFunction.CustomValues = customValues;
            accessRequestFunction.Stakeholders = stakeholders;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(accessRequestFunction, cancellationToken);
        }

        public Task<GetKMSInfoOutputDTO> GetKMSInfoQueryAsync(GetKMSInfoFunction getKMSInfoFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetKMSInfoFunction, GetKMSInfoOutputDTO>(getKMSInfoFunction, blockParameter);
        }

        public Task<GetKMSInfoOutputDTO> GetKMSInfoQueryAsync(byte[] prefix, BlockParameter blockParameter = null)
        {
            var getKMSInfoFunction = new GetKMSInfoFunction();
            getKMSInfoFunction.Prefix = prefix;

            return ContractHandler.QueryDeserializingToObjectAsync<GetKMSInfoFunction, GetKMSInfoOutputDTO>(getKMSInfoFunction, blockParameter);
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

        public Task<string> LibraryAddressQueryAsync(LibraryAddressFunction libraryAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LibraryAddressFunction, string>(libraryAddressFunction, blockParameter);
        }


        public Task<string> LibraryAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LibraryAddressFunction, string>(null, blockParameter);
        }

        public Task<string> AccessCompleteContextRequestAsync(AccessCompleteContextFunction accessCompleteContextFunction)
        {
            return ContractHandler.SendRequestAsync(accessCompleteContextFunction);
        }

        public Task<TransactionReceipt> AccessCompleteContextRequestAndWaitForReceiptAsync(AccessCompleteContextFunction accessCompleteContextFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(accessCompleteContextFunction, cancellationToken);
        }

        public Task<string> AccessCompleteContextRequestAsync(BigInteger requestNonce, byte[] contextHash, string accessor, BigInteger requestTimestamp)
        {
            var accessCompleteContextFunction = new AccessCompleteContextFunction();
            accessCompleteContextFunction.RequestNonce = requestNonce;
            accessCompleteContextFunction.ContextHash = contextHash;
            accessCompleteContextFunction.Accessor = accessor;
            accessCompleteContextFunction.RequestTimestamp = requestTimestamp;

            return ContractHandler.SendRequestAsync(accessCompleteContextFunction);
        }

        public Task<TransactionReceipt> AccessCompleteContextRequestAndWaitForReceiptAsync(BigInteger requestNonce, byte[] contextHash, string accessor, BigInteger requestTimestamp, CancellationTokenSource cancellationToken = null)
        {
            var accessCompleteContextFunction = new AccessCompleteContextFunction();
            accessCompleteContextFunction.RequestNonce = requestNonce;
            accessCompleteContextFunction.ContextHash = contextHash;
            accessCompleteContextFunction.Accessor = accessor;
            accessCompleteContextFunction.RequestTimestamp = requestTimestamp;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(accessCompleteContextFunction, cancellationToken);
        }

        public Task<GetCustomInfoOutputDTO> GetCustomInfoQueryAsync(GetCustomInfoFunction getCustomInfoFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetCustomInfoFunction, GetCustomInfoOutputDTO>(getCustomInfoFunction, blockParameter);
        }

        public Task<GetCustomInfoOutputDTO> GetCustomInfoQueryAsync(string accessor, List<byte[]> customValues, List<string> stakeholders, BlockParameter blockParameter = null)
        {
            var getCustomInfoFunction = new GetCustomInfoFunction();
            getCustomInfoFunction.Accessor = accessor;
            getCustomInfoFunction.CustomValues = customValues;
            getCustomInfoFunction.Stakeholders = stakeholders;

            return ContractHandler.QueryDeserializingToObjectAsync<GetCustomInfoFunction, GetCustomInfoOutputDTO>(getCustomInfoFunction, blockParameter);
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

        public Task<string> SetContentContractAddressRequestAsync(SetContentContractAddressFunction setContentContractAddressFunction)
        {
            return ContractHandler.SendRequestAsync(setContentContractAddressFunction);
        }

        public Task<TransactionReceipt> SetContentContractAddressRequestAndWaitForReceiptAsync(SetContentContractAddressFunction setContentContractAddressFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(setContentContractAddressFunction, cancellationToken);
        }

        public Task<string> SetContentContractAddressRequestAsync(string addr)
        {
            var setContentContractAddressFunction = new SetContentContractAddressFunction();
            setContentContractAddressFunction.Addr = addr;

            return ContractHandler.SendRequestAsync(setContentContractAddressFunction);
        }

        public Task<TransactionReceipt> SetContentContractAddressRequestAndWaitForReceiptAsync(string addr, CancellationTokenSource cancellationToken = null)
        {
            var setContentContractAddressFunction = new SetContentContractAddressFunction();
            setContentContractAddressFunction.Addr = addr;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(setContentContractAddressFunction, cancellationToken);
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

        public Task<string> SetAccessChargeRequestAsync(SetAccessChargeFunction setAccessChargeFunction)
        {
            return ContractHandler.SendRequestAsync(setAccessChargeFunction);
        }

        public Task<TransactionReceipt> SetAccessChargeRequestAndWaitForReceiptAsync(SetAccessChargeFunction setAccessChargeFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(setAccessChargeFunction, cancellationToken);
        }

        public Task<string> SetAccessChargeRequestAsync(BigInteger charge)
        {
            var setAccessChargeFunction = new SetAccessChargeFunction();
            setAccessChargeFunction.Charge = charge;

            return ContractHandler.SendRequestAsync(setAccessChargeFunction);
        }

        public Task<TransactionReceipt> SetAccessChargeRequestAndWaitForReceiptAsync(BigInteger charge, CancellationTokenSource cancellationToken = null)
        {
            var setAccessChargeFunction = new SetAccessChargeFunction();
            setAccessChargeFunction.Charge = charge;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(setAccessChargeFunction, cancellationToken);
        }
    }
}
