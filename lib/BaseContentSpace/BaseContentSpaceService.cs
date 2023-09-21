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
using Elv.NET.Contracts.BaseContentSpace.ContractDefinition;

namespace Elv.NET.Contracts.BaseContentSpace
{
    public partial class BaseContentSpaceService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, BaseContentSpaceDeployment baseContentSpaceDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<BaseContentSpaceDeployment>().SendRequestAndWaitForReceiptAsync(baseContentSpaceDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, BaseContentSpaceDeployment baseContentSpaceDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<BaseContentSpaceDeployment>().SendRequestAsync(baseContentSpaceDeployment);
        }

        public static async Task<BaseContentSpaceService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, BaseContentSpaceDeployment baseContentSpaceDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, baseContentSpaceDeployment, cancellationTokenSource);
            return new BaseContentSpaceService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3 { get; }

        public ContractHandler ContractHandler { get; }

        public BaseContentSpaceService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public BaseContentSpaceService(Nethereum.Web3.IWeb3 web3, string contractAddress)
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

        public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
        }


        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
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

        public Task<string> SubmitNodeRequestAsync(SubmitNodeFunction submitNodeFunction)
        {
            return ContractHandler.SendRequestAsync(submitNodeFunction);
        }

        public Task<TransactionReceipt> SubmitNodeRequestAndWaitForReceiptAsync(SubmitNodeFunction submitNodeFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(submitNodeFunction, cancellationToken);
        }

        public Task<string> SubmitNodeRequestAsync(byte[] locator)
        {
            var submitNodeFunction = new SubmitNodeFunction();
            submitNodeFunction.Locator = locator;

            return ContractHandler.SendRequestAsync(submitNodeFunction);
        }

        public Task<TransactionReceipt> SubmitNodeRequestAndWaitForReceiptAsync(byte[] locator, CancellationTokenSource cancellationToken = null)
        {
            var submitNodeFunction = new SubmitNodeFunction();
            submitNodeFunction.Locator = locator;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(submitNodeFunction, cancellationToken);
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

        public Task<bool> CanNodePublishQueryAsync(CanNodePublishFunction canNodePublishFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanNodePublishFunction, bool>(canNodePublishFunction, blockParameter);
        }


        public Task<bool> CanNodePublishQueryAsync(string candidate, BlockParameter blockParameter = null)
        {
            var canNodePublishFunction = new CanNodePublishFunction();
            canNodePublishFunction.Candidate = candidate;

            return ContractHandler.QueryAsync<CanNodePublishFunction, bool>(canNodePublishFunction, blockParameter);
        }

        public Task<GetKMSInfoOutputDTO> GetKMSInfoQueryAsync(GetKMSInfoFunction getKMSInfoFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetKMSInfoFunction, GetKMSInfoOutputDTO>(getKMSInfoFunction, blockParameter);
        }

        public Task<GetKMSInfoOutputDTO> GetKMSInfoQueryAsync(string kmsID, byte[] prefix, BlockParameter blockParameter = null)
        {
            var getKMSInfoFunction = new GetKMSInfoFunction();
            getKMSInfoFunction.KmsID = kmsID;
            getKMSInfoFunction.Prefix = prefix;

            return ContractHandler.QueryDeserializingToObjectAsync<GetKMSInfoFunction, GetKMSInfoOutputDTO>(getKMSInfoFunction, blockParameter);
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


        public Task<bool> CanReviewQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var canReviewFunction = new CanReviewFunction();
            canReviewFunction.ReturnValue1 = returnValue1;

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

        public Task<string> CreateLibraryRequestAsync(CreateLibraryFunction createLibraryFunction)
        {
            return ContractHandler.SendRequestAsync(createLibraryFunction);
        }

        public Task<TransactionReceipt> CreateLibraryRequestAndWaitForReceiptAsync(CreateLibraryFunction createLibraryFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(createLibraryFunction, cancellationToken);
        }

        public Task<string> CreateLibraryRequestAsync(string addressKms)
        {
            var createLibraryFunction = new CreateLibraryFunction();
            createLibraryFunction.AddressKms = addressKms;

            return ContractHandler.SendRequestAsync(createLibraryFunction);
        }

        public Task<TransactionReceipt> CreateLibraryRequestAndWaitForReceiptAsync(string addressKms, CancellationTokenSource cancellationToken = null)
        {
            var createLibraryFunction = new CreateLibraryFunction();
            createLibraryFunction.AddressKms = addressKms;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(createLibraryFunction, cancellationToken);
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

        public Task<BigInteger> NumActiveNodesQueryAsync(NumActiveNodesFunction numActiveNodesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NumActiveNodesFunction, BigInteger>(numActiveNodesFunction, blockParameter);
        }


        public Task<BigInteger> NumActiveNodesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NumActiveNodesFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> LibraryFactoryQueryAsync(LibraryFactoryFunction libraryFactoryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LibraryFactoryFunction, string>(libraryFactoryFunction, blockParameter);
        }


        public Task<string> LibraryFactoryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<LibraryFactoryFunction, string>(null, blockParameter);
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

        public Task<byte[]> ActiveNodeLocatorsQueryAsync(ActiveNodeLocatorsFunction activeNodeLocatorsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ActiveNodeLocatorsFunction, byte[]>(activeNodeLocatorsFunction, blockParameter);
        }


        public Task<byte[]> ActiveNodeLocatorsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var activeNodeLocatorsFunction = new ActiveNodeLocatorsFunction();
            activeNodeLocatorsFunction.ReturnValue1 = returnValue1;

            return ContractHandler.QueryAsync<ActiveNodeLocatorsFunction, byte[]>(activeNodeLocatorsFunction, blockParameter);
        }

        public Task<string> ActiveNodeAddressesQueryAsync(ActiveNodeAddressesFunction activeNodeAddressesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ActiveNodeAddressesFunction, string>(activeNodeAddressesFunction, blockParameter);
        }


        public Task<string> ActiveNodeAddressesQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var activeNodeAddressesFunction = new ActiveNodeAddressesFunction();
            activeNodeAddressesFunction.ReturnValue1 = returnValue1;

            return ContractHandler.QueryAsync<ActiveNodeAddressesFunction, string>(activeNodeAddressesFunction, blockParameter);
        }

        public Task<byte[]> VersionQueryAsync(VersionFunction versionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VersionFunction, byte[]>(versionFunction, blockParameter);
        }


        public Task<byte[]> VersionQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VersionFunction, byte[]>(null, blockParameter);
        }

        public Task<string> CreateGroupRequestAsync(CreateGroupFunction createGroupFunction)
        {
            return ContractHandler.SendRequestAsync(createGroupFunction);
        }

        public Task<string> CreateGroupRequestAsync()
        {
            return ContractHandler.SendRequestAsync<CreateGroupFunction>();
        }

        public Task<TransactionReceipt> CreateGroupRequestAndWaitForReceiptAsync(CreateGroupFunction createGroupFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(createGroupFunction, cancellationToken);
        }

        public Task<TransactionReceipt> CreateGroupRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync<CreateGroupFunction>(null, cancellationToken);
        }

        public Task<string> GetKMSIDQueryAsync(GetKMSIDFunction getKMSIDFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetKMSIDFunction, string>(getKMSIDFunction, blockParameter);
        }


        public Task<string> GetKMSIDQueryAsync(string kmsAddr, BlockParameter blockParameter = null)
        {
            var getKMSIDFunction = new GetKMSIDFunction();
            getKMSIDFunction.KmsAddr = kmsAddr;

            return ContractHandler.QueryAsync<GetKMSIDFunction, string>(getKMSIDFunction, blockParameter);
        }

        public Task<string> SetFactoryRequestAsync(SetFactoryFunction setFactoryFunction)
        {
            return ContractHandler.SendRequestAsync(setFactoryFunction);
        }

        public Task<TransactionReceipt> SetFactoryRequestAndWaitForReceiptAsync(SetFactoryFunction setFactoryFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(setFactoryFunction, cancellationToken);
        }

        public Task<string> SetFactoryRequestAsync(string newFactory)
        {
            var setFactoryFunction = new SetFactoryFunction();
            setFactoryFunction.NewFactory = newFactory;

            return ContractHandler.SendRequestAsync(setFactoryFunction);
        }

        public Task<TransactionReceipt> SetFactoryRequestAndWaitForReceiptAsync(string newFactory, CancellationTokenSource cancellationToken = null)
        {
            var setFactoryFunction = new SetFactoryFunction();
            setFactoryFunction.NewFactory = newFactory;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(setFactoryFunction, cancellationToken);
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

        public Task<string> UserWalletsQueryAsync(UserWalletsFunction userWalletsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<UserWalletsFunction, string>(userWalletsFunction, blockParameter);
        }


        public Task<string> UserWalletsQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var userWalletsFunction = new UserWalletsFunction();
            userWalletsFunction.ReturnValue1 = returnValue1;

            return ContractHandler.QueryAsync<UserWalletsFunction, string>(userWalletsFunction, blockParameter);
        }

        public Task<string> AddNodeRequestAsync(AddNodeFunction addNodeFunction)
        {
            return ContractHandler.SendRequestAsync(addNodeFunction);
        }

        public Task<TransactionReceipt> AddNodeRequestAndWaitForReceiptAsync(AddNodeFunction addNodeFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(addNodeFunction, cancellationToken);
        }

        public Task<string> AddNodeRequestAsync(string nodeAddr, byte[] locator)
        {
            var addNodeFunction = new AddNodeFunction();
            addNodeFunction.NodeAddr = nodeAddr;
            addNodeFunction.Locator = locator;

            return ContractHandler.SendRequestAsync(addNodeFunction);
        }

        public Task<TransactionReceipt> AddNodeRequestAndWaitForReceiptAsync(string nodeAddr, byte[] locator, CancellationTokenSource cancellationToken = null)
        {
            var addNodeFunction = new AddNodeFunction();
            addNodeFunction.NodeAddr = nodeAddr;
            addNodeFunction.Locator = locator;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(addNodeFunction, cancellationToken);
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

        public Task<byte[]> PendingNodeLocatorsQueryAsync(PendingNodeLocatorsFunction pendingNodeLocatorsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PendingNodeLocatorsFunction, byte[]>(pendingNodeLocatorsFunction, blockParameter);
        }


        public Task<byte[]> PendingNodeLocatorsQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var pendingNodeLocatorsFunction = new PendingNodeLocatorsFunction();
            pendingNodeLocatorsFunction.ReturnValue1 = returnValue1;

            return ContractHandler.QueryAsync<PendingNodeLocatorsFunction, byte[]>(pendingNodeLocatorsFunction, blockParameter);
        }

        public Task<string> PendingNodeAddressesQueryAsync(PendingNodeAddressesFunction pendingNodeAddressesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PendingNodeAddressesFunction, string>(pendingNodeAddressesFunction, blockParameter);
        }


        public Task<string> PendingNodeAddressesQueryAsync(BigInteger returnValue1, BlockParameter blockParameter = null)
        {
            var pendingNodeAddressesFunction = new PendingNodeAddressesFunction();
            pendingNodeAddressesFunction.ReturnValue1 = returnValue1;

            return ContractHandler.QueryAsync<PendingNodeAddressesFunction, string>(pendingNodeAddressesFunction, blockParameter);
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

        public Task<string> DescriptionQueryAsync(DescriptionFunction descriptionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DescriptionFunction, string>(descriptionFunction, blockParameter);
        }


        public Task<string> DescriptionQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DescriptionFunction, string>(null, blockParameter);
        }

        public Task<string> CreateAccessWalletRequestAsync(CreateAccessWalletFunction createAccessWalletFunction)
        {
            return ContractHandler.SendRequestAsync(createAccessWalletFunction);
        }

        public Task<string> CreateAccessWalletRequestAsync()
        {
            return ContractHandler.SendRequestAsync<CreateAccessWalletFunction>();
        }

        public Task<TransactionReceipt> CreateAccessWalletRequestAndWaitForReceiptAsync(CreateAccessWalletFunction createAccessWalletFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(createAccessWalletFunction, cancellationToken);
        }

        public Task<TransactionReceipt> CreateAccessWalletRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync<CreateAccessWalletFunction>(null, cancellationToken);
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

        public Task<string> SetWalletFactoryRequestAsync(SetWalletFactoryFunction setWalletFactoryFunction)
        {
            return ContractHandler.SendRequestAsync(setWalletFactoryFunction);
        }

        public Task<TransactionReceipt> SetWalletFactoryRequestAndWaitForReceiptAsync(SetWalletFactoryFunction setWalletFactoryFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(setWalletFactoryFunction, cancellationToken);
        }

        public Task<string> SetWalletFactoryRequestAsync(string newFactory)
        {
            var setWalletFactoryFunction = new SetWalletFactoryFunction();
            setWalletFactoryFunction.NewFactory = newFactory;

            return ContractHandler.SendRequestAsync(setWalletFactoryFunction);
        }

        public Task<TransactionReceipt> SetWalletFactoryRequestAndWaitForReceiptAsync(string newFactory, CancellationTokenSource cancellationToken = null)
        {
            var setWalletFactoryFunction = new SetWalletFactoryFunction();
            setWalletFactoryFunction.NewFactory = newFactory;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(setWalletFactoryFunction, cancellationToken);
        }

        public Task<bool> CanEditQueryAsync(CanEditFunction canEditFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanEditFunction, bool>(canEditFunction, blockParameter);
        }


        public Task<bool> CanEditQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanEditFunction, bool>(null, blockParameter);
        }

        public Task<string> SetGroupFactoryRequestAsync(SetGroupFactoryFunction setGroupFactoryFunction)
        {
            return ContractHandler.SendRequestAsync(setGroupFactoryFunction);
        }

        public Task<TransactionReceipt> SetGroupFactoryRequestAndWaitForReceiptAsync(SetGroupFactoryFunction setGroupFactoryFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(setGroupFactoryFunction, cancellationToken);
        }

        public Task<string> SetGroupFactoryRequestAsync(string newFactory)
        {
            var setGroupFactoryFunction = new SetGroupFactoryFunction();
            setGroupFactoryFunction.NewFactory = newFactory;

            return ContractHandler.SendRequestAsync(setGroupFactoryFunction);
        }

        public Task<TransactionReceipt> SetGroupFactoryRequestAndWaitForReceiptAsync(string newFactory, CancellationTokenSource cancellationToken = null)
        {
            var setGroupFactoryFunction = new SetGroupFactoryFunction();
            setGroupFactoryFunction.NewFactory = newFactory;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(setGroupFactoryFunction, cancellationToken);
        }

        public Task<string> SetContentFactoryRequestAsync(SetContentFactoryFunction setContentFactoryFunction)
        {
            return ContractHandler.SendRequestAsync(setContentFactoryFunction);
        }

        public Task<TransactionReceipt> SetContentFactoryRequestAndWaitForReceiptAsync(SetContentFactoryFunction setContentFactoryFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(setContentFactoryFunction, cancellationToken);
        }

        public Task<string> SetContentFactoryRequestAsync(string newFactory)
        {
            var setContentFactoryFunction = new SetContentFactoryFunction();
            setContentFactoryFunction.NewFactory = newFactory;

            return ContractHandler.SendRequestAsync(setContentFactoryFunction);
        }

        public Task<TransactionReceipt> SetContentFactoryRequestAndWaitForReceiptAsync(string newFactory, CancellationTokenSource cancellationToken = null)
        {
            var setContentFactoryFunction = new SetContentFactoryFunction();
            setContentFactoryFunction.NewFactory = newFactory;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(setContentFactoryFunction, cancellationToken);
        }

        public Task<string> SetKmsManagerRequestAsync(SetKmsManagerFunction setKmsManagerFunction)
        {
            return ContractHandler.SendRequestAsync(setKmsManagerFunction);
        }

        public Task<TransactionReceipt> SetKmsManagerRequestAndWaitForReceiptAsync(SetKmsManagerFunction setKmsManagerFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(setKmsManagerFunction, cancellationToken);
        }

        public Task<string> SetKmsManagerRequestAsync(string kmsManAddr)
        {
            var setKmsManagerFunction = new SetKmsManagerFunction();
            setKmsManagerFunction.KmsManAddr = kmsManAddr;

            return ContractHandler.SendRequestAsync(setKmsManagerFunction);
        }

        public Task<TransactionReceipt> SetKmsManagerRequestAndWaitForReceiptAsync(string kmsManAddr, CancellationTokenSource cancellationToken = null)
        {
            var setKmsManagerFunction = new SetKmsManagerFunction();
            setKmsManagerFunction.KmsManAddr = kmsManAddr;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(setKmsManagerFunction, cancellationToken);
        }

        public Task<BigInteger> CheckKMSQueryAsync(CheckKMSFunction checkKMSFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CheckKMSFunction, BigInteger>(checkKMSFunction, blockParameter);
        }


        public Task<BigInteger> CheckKMSQueryAsync(string kmsIdStr, BlockParameter blockParameter = null)
        {
            var checkKMSFunction = new CheckKMSFunction();
            checkKMSFunction.KmsIdStr = kmsIdStr;

            return ContractHandler.QueryAsync<CheckKMSFunction, BigInteger>(checkKMSFunction, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }


        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> ContentFactoryQueryAsync(ContentFactoryFunction contentFactoryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContentFactoryFunction, string>(contentFactoryFunction, blockParameter);
        }


        public Task<string> ContentFactoryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContentFactoryFunction, string>(null, blockParameter);
        }

        public Task<string> SetDescriptionRequestAsync(SetDescriptionFunction setDescriptionFunction)
        {
            return ContractHandler.SendRequestAsync(setDescriptionFunction);
        }

        public Task<TransactionReceipt> SetDescriptionRequestAndWaitForReceiptAsync(SetDescriptionFunction setDescriptionFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(setDescriptionFunction, cancellationToken);
        }

        public Task<string> SetDescriptionRequestAsync(string contentSpaceDescription)
        {
            var setDescriptionFunction = new SetDescriptionFunction();
            setDescriptionFunction.ContentSpaceDescription = contentSpaceDescription;

            return ContractHandler.SendRequestAsync(setDescriptionFunction);
        }

        public Task<TransactionReceipt> SetDescriptionRequestAndWaitForReceiptAsync(string contentSpaceDescription, CancellationTokenSource cancellationToken = null)
        {
            var setDescriptionFunction = new SetDescriptionFunction();
            setDescriptionFunction.ContentSpaceDescription = contentSpaceDescription;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(setDescriptionFunction, cancellationToken);
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

        public Task<bool> CanPublishQueryAsync(CanPublishFunction canPublishFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanPublishFunction, bool>(canPublishFunction, blockParameter);
        }


        public Task<bool> CanPublishQueryAsync(string candidate, BlockParameter blockParameter = null)
        {
            var canPublishFunction = new CanPublishFunction();
            canPublishFunction.Candidate = candidate;

            return ContractHandler.QueryAsync<CanPublishFunction, bool>(canPublishFunction, blockParameter);
        }

        public Task<string> KmsManAddrQueryAsync(KmsManAddrFunction kmsManAddrFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<KmsManAddrFunction, string>(kmsManAddrFunction, blockParameter);
        }


        public Task<string> KmsManAddrQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<KmsManAddrFunction, string>(null, blockParameter);
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

        public Task<string> SetLibraryFactoryRequestAsync(SetLibraryFactoryFunction setLibraryFactoryFunction)
        {
            return ContractHandler.SendRequestAsync(setLibraryFactoryFunction);
        }

        public Task<TransactionReceipt> SetLibraryFactoryRequestAndWaitForReceiptAsync(SetLibraryFactoryFunction setLibraryFactoryFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(setLibraryFactoryFunction, cancellationToken);
        }

        public Task<string> SetLibraryFactoryRequestAsync(string newFactory)
        {
            var setLibraryFactoryFunction = new SetLibraryFactoryFunction();
            setLibraryFactoryFunction.NewFactory = newFactory;

            return ContractHandler.SendRequestAsync(setLibraryFactoryFunction);
        }

        public Task<TransactionReceipt> SetLibraryFactoryRequestAndWaitForReceiptAsync(string newFactory, CancellationTokenSource cancellationToken = null)
        {
            var setLibraryFactoryFunction = new SetLibraryFactoryFunction();
            setLibraryFactoryFunction.NewFactory = newFactory;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(setLibraryFactoryFunction, cancellationToken);
        }

        public Task<string> GetAccessWalletRequestAsync(GetAccessWalletFunction getAccessWalletFunction)
        {
            return ContractHandler.SendRequestAsync(getAccessWalletFunction);
        }

        public Task<string> GetAccessWalletRequestAsync()
        {
            return ContractHandler.SendRequestAsync<GetAccessWalletFunction>();
        }

        public Task<TransactionReceipt> GetAccessWalletRequestAndWaitForReceiptAsync(GetAccessWalletFunction getAccessWalletFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(getAccessWalletFunction, cancellationToken);
        }

        public Task<TransactionReceipt> GetAccessWalletRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync<GetAccessWalletFunction>(null, cancellationToken);
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

        public Task<string> GroupFactoryQueryAsync(GroupFactoryFunction groupFactoryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GroupFactoryFunction, string>(groupFactoryFunction, blockParameter);
        }


        public Task<string> GroupFactoryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GroupFactoryFunction, string>(null, blockParameter);
        }

        public Task<string> RemoveNodeRequestAsync(RemoveNodeFunction removeNodeFunction)
        {
            return ContractHandler.SendRequestAsync(removeNodeFunction);
        }

        public Task<TransactionReceipt> RemoveNodeRequestAndWaitForReceiptAsync(RemoveNodeFunction removeNodeFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(removeNodeFunction, cancellationToken);
        }

        public Task<string> RemoveNodeRequestAsync(string nodeAddr)
        {
            var removeNodeFunction = new RemoveNodeFunction();
            removeNodeFunction.NodeAddr = nodeAddr;

            return ContractHandler.SendRequestAsync(removeNodeFunction);
        }

        public Task<TransactionReceipt> RemoveNodeRequestAndWaitForReceiptAsync(string nodeAddr, CancellationTokenSource cancellationToken = null)
        {
            var removeNodeFunction = new RemoveNodeFunction();
            removeNodeFunction.NodeAddr = nodeAddr;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(removeNodeFunction, cancellationToken);
        }

        public Task<string> CreateContentTypeRequestAsync(CreateContentTypeFunction createContentTypeFunction)
        {
            return ContractHandler.SendRequestAsync(createContentTypeFunction);
        }

        public Task<string> CreateContentTypeRequestAsync()
        {
            return ContractHandler.SendRequestAsync<CreateContentTypeFunction>();
        }

        public Task<TransactionReceipt> CreateContentTypeRequestAndWaitForReceiptAsync(CreateContentTypeFunction createContentTypeFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(createContentTypeFunction, cancellationToken);
        }

        public Task<TransactionReceipt> CreateContentTypeRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync<CreateContentTypeFunction>(null, cancellationToken);
        }

        public Task<string> CreateContentRequestAsync(CreateContentFunction createContentFunction)
        {
            return ContractHandler.SendRequestAsync(createContentFunction);
        }

        public Task<TransactionReceipt> CreateContentRequestAndWaitForReceiptAsync(CreateContentFunction createContentFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(createContentFunction, cancellationToken);
        }

        public Task<string> CreateContentRequestAsync(string lib, string contentType)
        {
            var createContentFunction = new CreateContentFunction();
            createContentFunction.Lib = lib;
            createContentFunction.ContentType = contentType;

            return ContractHandler.SendRequestAsync(createContentFunction);
        }

        public Task<TransactionReceipt> CreateContentRequestAndWaitForReceiptAsync(string lib, string contentType, CancellationTokenSource cancellationToken = null)
        {
            var createContentFunction = new CreateContentFunction();
            createContentFunction.Lib = lib;
            createContentFunction.ContentType = contentType;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(createContentFunction, cancellationToken);
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

        public Task<string> FactoryQueryAsync(FactoryFunction factoryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FactoryFunction, string>(factoryFunction, blockParameter);
        }


        public Task<string> FactoryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FactoryFunction, string>(null, blockParameter);
        }

        public Task<string> WalletFactoryQueryAsync(WalletFactoryFunction walletFactoryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WalletFactoryFunction, string>(walletFactoryFunction, blockParameter);
        }


        public Task<string> WalletFactoryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WalletFactoryFunction, string>(null, blockParameter);
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

        public Task<BigInteger> CheckKMSAddrQueryAsync(CheckKMSAddrFunction checkKMSAddrFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CheckKMSAddrFunction, BigInteger>(checkKMSAddrFunction, blockParameter);
        }


        public Task<BigInteger> CheckKMSAddrQueryAsync(string kmsAddr, BlockParameter blockParameter = null)
        {
            var checkKMSAddrFunction = new CheckKMSAddrFunction();
            checkKMSAddrFunction.KmsAddr = kmsAddr;

            return ContractHandler.QueryAsync<CheckKMSAddrFunction, BigInteger>(checkKMSAddrFunction, blockParameter);
        }

        public Task<string> ApproveNodeRequestAsync(ApproveNodeFunction approveNodeFunction)
        {
            return ContractHandler.SendRequestAsync(approveNodeFunction);
        }

        public Task<TransactionReceipt> ApproveNodeRequestAndWaitForReceiptAsync(ApproveNodeFunction approveNodeFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(approveNodeFunction, cancellationToken);
        }

        public Task<string> ApproveNodeRequestAsync(string nodeAddr)
        {
            var approveNodeFunction = new ApproveNodeFunction();
            approveNodeFunction.NodeAddr = nodeAddr;

            return ContractHandler.SendRequestAsync(approveNodeFunction);
        }

        public Task<TransactionReceipt> ApproveNodeRequestAndWaitForReceiptAsync(string nodeAddr, CancellationTokenSource cancellationToken = null)
        {
            var approveNodeFunction = new ApproveNodeFunction();
            approveNodeFunction.NodeAddr = nodeAddr;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(approveNodeFunction, cancellationToken);
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

        public Task<string> CreateUserWalletRequestAsync(CreateUserWalletFunction createUserWalletFunction)
        {
            return ContractHandler.SendRequestAsync(createUserWalletFunction);
        }

        public Task<TransactionReceipt> CreateUserWalletRequestAndWaitForReceiptAsync(CreateUserWalletFunction createUserWalletFunction, CancellationTokenSource cancellationToken = null)
        {
            return ContractHandler.SendRequestAndWaitForReceiptAsync(createUserWalletFunction, cancellationToken);
        }

        public Task<string> CreateUserWalletRequestAsync(string user)
        {
            var createUserWalletFunction = new CreateUserWalletFunction();
            createUserWalletFunction.User = user;

            return ContractHandler.SendRequestAsync(createUserWalletFunction);
        }

        public Task<TransactionReceipt> CreateUserWalletRequestAndWaitForReceiptAsync(string user, CancellationTokenSource cancellationToken = null)
        {
            var createUserWalletFunction = new CreateUserWalletFunction();
            createUserWalletFunction.User = user;

            return ContractHandler.SendRequestAndWaitForReceiptAsync(createUserWalletFunction, cancellationToken);
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

        public Task<BigInteger> NumPendingNodesQueryAsync(NumPendingNodesFunction numPendingNodesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NumPendingNodesFunction, BigInteger>(numPendingNodesFunction, blockParameter);
        }


        public Task<BigInteger> NumPendingNodesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NumPendingNodesFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> NodeMappingQueryAsync(NodeMappingFunction nodeMappingFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NodeMappingFunction, string>(nodeMappingFunction, blockParameter);
        }


        public Task<string> NodeMappingQueryAsync(string returnValue1, BlockParameter blockParameter = null)
        {
            var nodeMappingFunction = new NodeMappingFunction();
            nodeMappingFunction.ReturnValue1 = returnValue1;

            return ContractHandler.QueryAsync<NodeMappingFunction, string>(nodeMappingFunction, blockParameter);
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
