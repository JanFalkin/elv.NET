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
using Elv.NET.Contracts.AccessIndexor.ContractDefinition;

namespace Elv.NET.Contracts.AccessIndexor
{
    public partial class AccessIndexorService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, AccessIndexorDeployment accessIndexorDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<AccessIndexorDeployment>().SendRequestAndWaitForReceiptAsync(accessIndexorDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, AccessIndexorDeployment accessIndexorDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<AccessIndexorDeployment>().SendRequestAsync(accessIndexorDeployment);
        }

        public static async Task<AccessIndexorService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, AccessIndexorDeployment accessIndexorDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, accessIndexorDeployment, cancellationTokenSource);
            return new AccessIndexorService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public AccessIndexorService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public AccessIndexorService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> CreatorQueryAsync(CreatorFunction creatorFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CreatorFunction, string>(creatorFunction, blockParameter);
        }

        
        public Task<string> CreatorQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CreatorFunction, string>(null, blockParameter);
        }

        public Task<string> CleanUpContentObjectsRequestAsync(CleanUpContentObjectsFunction cleanUpContentObjectsFunction)
        {
             return ContractHandler.SendRequestAsync(cleanUpContentObjectsFunction);
        }

        public Task<string> CleanUpContentObjectsRequestAsync()
        {
             return ContractHandler.SendRequestAsync<CleanUpContentObjectsFunction>();
        }

        public Task<TransactionReceipt> CleanUpContentObjectsRequestAndWaitForReceiptAsync(CleanUpContentObjectsFunction cleanUpContentObjectsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cleanUpContentObjectsFunction, cancellationToken);
        }

        public Task<TransactionReceipt> CleanUpContentObjectsRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<CleanUpContentObjectsFunction>(null, cancellationToken);
        }

        public Task<string> SetContentSpaceRequestAsync(SetContentSpaceFunction setContentSpaceFunction)
        {
             return ContractHandler.SendRequestAsync(setContentSpaceFunction);
        }

        public Task<TransactionReceipt> SetContentSpaceRequestAndWaitForReceiptAsync(SetContentSpaceFunction setContentSpaceFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContentSpaceFunction, cancellationToken);
        }

        public Task<string> SetContentSpaceRequestAsync(string contentSpace)
        {
            var setContentSpaceFunction = new SetContentSpaceFunction();
                setContentSpaceFunction.ContentSpace = contentSpace;
            
             return ContractHandler.SendRequestAsync(setContentSpaceFunction);
        }

        public Task<TransactionReceipt> SetContentSpaceRequestAndWaitForReceiptAsync(string contentSpace, CancellationTokenSource cancellationToken = null)
        {
            var setContentSpaceFunction = new SetContentSpaceFunction();
                setContentSpaceFunction.ContentSpace = contentSpace;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContentSpaceFunction, cancellationToken);
        }

        public Task<byte> GetContractRightsQueryAsync(GetContractRightsFunction getContractRightsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetContractRightsFunction, byte>(getContractRightsFunction, blockParameter);
        }

        
        public Task<byte> GetContractRightsQueryAsync(string obj, BlockParameter blockParameter = null)
        {
            var getContractRightsFunction = new GetContractRightsFunction();
                getContractRightsFunction.Obj = obj;
            
            return ContractHandler.QueryAsync<GetContractRightsFunction, byte>(getContractRightsFunction, blockParameter);
        }

        public Task<byte> CategoryContentObjectQueryAsync(CategoryContentObjectFunction categoryContentObjectFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CategoryContentObjectFunction, byte>(categoryContentObjectFunction, blockParameter);
        }

        
        public Task<byte> CategoryContentObjectQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CategoryContentObjectFunction, byte>(null, blockParameter);
        }

        public Task<BigInteger> GetAccessGroupsLengthQueryAsync(GetAccessGroupsLengthFunction getAccessGroupsLengthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetAccessGroupsLengthFunction, BigInteger>(getAccessGroupsLengthFunction, blockParameter);
        }

        
        public Task<BigInteger> GetAccessGroupsLengthQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetAccessGroupsLengthFunction, BigInteger>(null, blockParameter);
        }

        public Task<byte> CategoryGroupQueryAsync(CategoryGroupFunction categoryGroupFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CategoryGroupFunction, byte>(categoryGroupFunction, blockParameter);
        }

        
        public Task<byte> CategoryGroupQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CategoryGroupFunction, byte>(null, blockParameter);
        }

        public Task<bool> CheckAccessGroupRightsQueryAsync(CheckAccessGroupRightsFunction checkAccessGroupRightsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CheckAccessGroupRightsFunction, bool>(checkAccessGroupRightsFunction, blockParameter);
        }

        
        public Task<bool> CheckAccessGroupRightsQueryAsync(string group, byte accessType, BlockParameter blockParameter = null)
        {
            var checkAccessGroupRightsFunction = new CheckAccessGroupRightsFunction();
                checkAccessGroupRightsFunction.Group = group;
                checkAccessGroupRightsFunction.AccessType = accessType;
            
            return ContractHandler.QueryAsync<CheckAccessGroupRightsFunction, bool>(checkAccessGroupRightsFunction, blockParameter);
        }

        public Task<byte> CategoryLibraryQueryAsync(CategoryLibraryFunction categoryLibraryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CategoryLibraryFunction, byte>(categoryLibraryFunction, blockParameter);
        }

        
        public Task<byte> CategoryLibraryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CategoryLibraryFunction, byte>(null, blockParameter);
        }

        public Task<byte> AccessConfirmedQueryAsync(AccessConfirmedFunction accessConfirmedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AccessConfirmedFunction, byte>(accessConfirmedFunction, blockParameter);
        }

        
        public Task<byte> AccessConfirmedQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AccessConfirmedFunction, byte>(null, blockParameter);
        }

        public Task<string> SetContractRightsRequestAsync(SetContractRightsFunction setContractRightsFunction)
        {
             return ContractHandler.SendRequestAsync(setContractRightsFunction);
        }

        public Task<TransactionReceipt> SetContractRightsRequestAndWaitForReceiptAsync(SetContractRightsFunction setContractRightsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContractRightsFunction, cancellationToken);
        }

        public Task<string> SetContractRightsRequestAsync(string obj, byte accessType, byte access)
        {
            var setContractRightsFunction = new SetContractRightsFunction();
                setContractRightsFunction.Obj = obj;
                setContractRightsFunction.AccessType = accessType;
                setContractRightsFunction.Access = access;
            
             return ContractHandler.SendRequestAsync(setContractRightsFunction);
        }

        public Task<TransactionReceipt> SetContractRightsRequestAndWaitForReceiptAsync(string obj, byte accessType, byte access, CancellationTokenSource cancellationToken = null)
        {
            var setContractRightsFunction = new SetContractRightsFunction();
                setContractRightsFunction.Obj = obj;
                setContractRightsFunction.AccessType = accessType;
                setContractRightsFunction.Access = access;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContractRightsFunction, cancellationToken);
        }

        public Task<string> GetAccessGroupQueryAsync(GetAccessGroupFunction getAccessGroupFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetAccessGroupFunction, string>(getAccessGroupFunction, blockParameter);
        }

        
        public Task<string> GetAccessGroupQueryAsync(BigInteger position, BlockParameter blockParameter = null)
        {
            var getAccessGroupFunction = new GetAccessGroupFunction();
                getAccessGroupFunction.Position = position;
            
            return ContractHandler.QueryAsync<GetAccessGroupFunction, string>(getAccessGroupFunction, blockParameter);
        }

        public Task<string> CleanUpAllRequestAsync(CleanUpAllFunction cleanUpAllFunction)
        {
             return ContractHandler.SendRequestAsync(cleanUpAllFunction);
        }

        public Task<string> CleanUpAllRequestAsync()
        {
             return ContractHandler.SendRequestAsync<CleanUpAllFunction>();
        }

        public Task<TransactionReceipt> CleanUpAllRequestAndWaitForReceiptAsync(CleanUpAllFunction cleanUpAllFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cleanUpAllFunction, cancellationToken);
        }

        public Task<TransactionReceipt> CleanUpAllRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<CleanUpAllFunction>(null, cancellationToken);
        }

        public Task<byte> GetAccessGroupRightsQueryAsync(GetAccessGroupRightsFunction getAccessGroupRightsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetAccessGroupRightsFunction, byte>(getAccessGroupRightsFunction, blockParameter);
        }

        
        public Task<byte> GetAccessGroupRightsQueryAsync(string group, BlockParameter blockParameter = null)
        {
            var getAccessGroupRightsFunction = new GetAccessGroupRightsFunction();
                getAccessGroupRightsFunction.Group = group;
            
            return ContractHandler.QueryAsync<GetAccessGroupRightsFunction, byte>(getAccessGroupRightsFunction, blockParameter);
        }

        public Task<AccessGroupsOutputDTO> AccessGroupsQueryAsync(AccessGroupsFunction accessGroupsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<AccessGroupsFunction, AccessGroupsOutputDTO>(accessGroupsFunction, blockParameter);
        }

        public Task<AccessGroupsOutputDTO> AccessGroupsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<AccessGroupsFunction, AccessGroupsOutputDTO>(null, blockParameter);
        }

        public Task<string> SetContentObjectRightsRequestAsync(SetContentObjectRightsFunction setContentObjectRightsFunction)
        {
             return ContractHandler.SendRequestAsync(setContentObjectRightsFunction);
        }

        public Task<TransactionReceipt> SetContentObjectRightsRequestAndWaitForReceiptAsync(SetContentObjectRightsFunction setContentObjectRightsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContentObjectRightsFunction, cancellationToken);
        }

        public Task<string> SetContentObjectRightsRequestAsync(string obj, byte accessType, byte access)
        {
            var setContentObjectRightsFunction = new SetContentObjectRightsFunction();
                setContentObjectRightsFunction.Obj = obj;
                setContentObjectRightsFunction.AccessType = accessType;
                setContentObjectRightsFunction.Access = access;
            
             return ContractHandler.SendRequestAsync(setContentObjectRightsFunction);
        }

        public Task<TransactionReceipt> SetContentObjectRightsRequestAndWaitForReceiptAsync(string obj, byte accessType, byte access, CancellationTokenSource cancellationToken = null)
        {
            var setContentObjectRightsFunction = new SetContentObjectRightsFunction();
                setContentObjectRightsFunction.Obj = obj;
                setContentObjectRightsFunction.AccessType = accessType;
                setContentObjectRightsFunction.Access = access;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContentObjectRightsFunction, cancellationToken);
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

        public Task<bool> HasManagerAccessQueryAsync(HasManagerAccessFunction hasManagerAccessFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasManagerAccessFunction, bool>(hasManagerAccessFunction, blockParameter);
        }

        
        public Task<bool> HasManagerAccessQueryAsync(string candidate, BlockParameter blockParameter = null)
        {
            var hasManagerAccessFunction = new HasManagerAccessFunction();
                hasManagerAccessFunction.Candidate = candidate;
            
            return ContractHandler.QueryAsync<HasManagerAccessFunction, bool>(hasManagerAccessFunction, blockParameter);
        }

        public Task<byte> AccessTentativeQueryAsync(AccessTentativeFunction accessTentativeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AccessTentativeFunction, byte>(accessTentativeFunction, blockParameter);
        }

        
        public Task<byte> AccessTentativeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AccessTentativeFunction, byte>(null, blockParameter);
        }

        public Task<OthersOutputDTO> OthersQueryAsync(OthersFunction othersFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<OthersFunction, OthersOutputDTO>(othersFunction, blockParameter);
        }

        public Task<OthersOutputDTO> OthersQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<OthersFunction, OthersOutputDTO>(null, blockParameter);
        }

        public Task<byte[]> VersionQueryAsync(VersionFunction versionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VersionFunction, byte[]>(versionFunction, blockParameter);
        }

        
        public Task<byte[]> VersionQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VersionFunction, byte[]>(null, blockParameter);
        }

        public Task<BigInteger> GetContentTypesLengthQueryAsync(GetContentTypesLengthFunction getContentTypesLengthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetContentTypesLengthFunction, BigInteger>(getContentTypesLengthFunction, blockParameter);
        }

        
        public Task<BigInteger> GetContentTypesLengthQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetContentTypesLengthFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> SetEntityRightsRequestAsync(SetEntityRightsFunction setEntityRightsFunction)
        {
             return ContractHandler.SendRequestAsync(setEntityRightsFunction);
        }

        public Task<TransactionReceipt> SetEntityRightsRequestAndWaitForReceiptAsync(SetEntityRightsFunction setEntityRightsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setEntityRightsFunction, cancellationToken);
        }

        public Task<string> SetEntityRightsRequestAsync(byte indexType, string obj, byte accessType, byte access)
        {
            var setEntityRightsFunction = new SetEntityRightsFunction();
                setEntityRightsFunction.IndexType = indexType;
                setEntityRightsFunction.Obj = obj;
                setEntityRightsFunction.AccessType = accessType;
                setEntityRightsFunction.Access = access;
            
             return ContractHandler.SendRequestAsync(setEntityRightsFunction);
        }

        public Task<TransactionReceipt> SetEntityRightsRequestAndWaitForReceiptAsync(byte indexType, string obj, byte accessType, byte access, CancellationTokenSource cancellationToken = null)
        {
            var setEntityRightsFunction = new SetEntityRightsFunction();
                setEntityRightsFunction.IndexType = indexType;
                setEntityRightsFunction.Obj = obj;
                setEntityRightsFunction.AccessType = accessType;
                setEntityRightsFunction.Access = access;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setEntityRightsFunction, cancellationToken);
        }

        public Task<byte> TypeEditQueryAsync(TypeEditFunction typeEditFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TypeEditFunction, byte>(typeEditFunction, blockParameter);
        }

        
        public Task<byte> TypeEditQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TypeEditFunction, byte>(null, blockParameter);
        }

        public Task<byte[]> VersionAPIQueryAsync(VersionAPIFunction versionAPIFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VersionAPIFunction, byte[]>(versionAPIFunction, blockParameter);
        }

        
        public Task<byte[]> VersionAPIQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VersionAPIFunction, byte[]>(null, blockParameter);
        }

        public Task<bool> CheckContentObjectRightsQueryAsync(CheckContentObjectRightsFunction checkContentObjectRightsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CheckContentObjectRightsFunction, bool>(checkContentObjectRightsFunction, blockParameter);
        }

        
        public Task<bool> CheckContentObjectRightsQueryAsync(string obj, byte accessType, BlockParameter blockParameter = null)
        {
            var checkContentObjectRightsFunction = new CheckContentObjectRightsFunction();
                checkContentObjectRightsFunction.Obj = obj;
                checkContentObjectRightsFunction.AccessType = accessType;
            
            return ContractHandler.QueryAsync<CheckContentObjectRightsFunction, bool>(checkContentObjectRightsFunction, blockParameter);
        }

        public Task<byte> CategoryContractQueryAsync(CategoryContractFunction categoryContractFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CategoryContractFunction, byte>(categoryContractFunction, blockParameter);
        }

        
        public Task<byte> CategoryContractQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CategoryContractFunction, byte>(null, blockParameter);
        }

        public Task<bool> CheckLibraryRightsQueryAsync(CheckLibraryRightsFunction checkLibraryRightsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CheckLibraryRightsFunction, bool>(checkLibraryRightsFunction, blockParameter);
        }

        
        public Task<bool> CheckLibraryRightsQueryAsync(string lib, byte accessType, BlockParameter blockParameter = null)
        {
            var checkLibraryRightsFunction = new CheckLibraryRightsFunction();
                checkLibraryRightsFunction.Lib = lib;
                checkLibraryRightsFunction.AccessType = accessType;
            
            return ContractHandler.QueryAsync<CheckLibraryRightsFunction, bool>(checkLibraryRightsFunction, blockParameter);
        }

        public Task<byte> CategoryContentTypeQueryAsync(CategoryContentTypeFunction categoryContentTypeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CategoryContentTypeFunction, byte>(categoryContentTypeFunction, blockParameter);
        }

        
        public Task<byte> CategoryContentTypeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CategoryContentTypeFunction, byte>(null, blockParameter);
        }

        public Task<byte> GetContentObjectRightsQueryAsync(GetContentObjectRightsFunction getContentObjectRightsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetContentObjectRightsFunction, byte>(getContentObjectRightsFunction, blockParameter);
        }

        
        public Task<byte> GetContentObjectRightsQueryAsync(string obj, BlockParameter blockParameter = null)
        {
            var getContentObjectRightsFunction = new GetContentObjectRightsFunction();
                getContentObjectRightsFunction.Obj = obj;
            
            return ContractHandler.QueryAsync<GetContentObjectRightsFunction, byte>(getContentObjectRightsFunction, blockParameter);
        }

        public Task<ContractsOutputDTO> ContractsQueryAsync(ContractsFunction contractsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ContractsFunction, ContractsOutputDTO>(contractsFunction, blockParameter);
        }

        public Task<ContractsOutputDTO> ContractsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ContractsFunction, ContractsOutputDTO>(null, blockParameter);
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

        public Task<string> GetContractQueryAsync(GetContractFunction getContractFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetContractFunction, string>(getContractFunction, blockParameter);
        }

        
        public Task<string> GetContractQueryAsync(BigInteger position, BlockParameter blockParameter = null)
        {
            var getContractFunction = new GetContractFunction();
                getContractFunction.Position = position;
            
            return ContractHandler.QueryAsync<GetContractFunction, string>(getContractFunction, blockParameter);
        }

        public Task<bool> ContractExistsQueryAsync(ContractExistsFunction contractExistsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContractExistsFunction, bool>(contractExistsFunction, blockParameter);
        }

        
        public Task<bool> ContractExistsQueryAsync(string addr, BlockParameter blockParameter = null)
        {
            var contractExistsFunction = new ContractExistsFunction();
                contractExistsFunction.Addr = addr;
            
            return ContractHandler.QueryAsync<ContractExistsFunction, bool>(contractExistsFunction, blockParameter);
        }

        public Task<string> SetLibraryRightsRequestAsync(SetLibraryRightsFunction setLibraryRightsFunction)
        {
             return ContractHandler.SendRequestAsync(setLibraryRightsFunction);
        }

        public Task<TransactionReceipt> SetLibraryRightsRequestAndWaitForReceiptAsync(SetLibraryRightsFunction setLibraryRightsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setLibraryRightsFunction, cancellationToken);
        }

        public Task<string> SetLibraryRightsRequestAsync(string lib, byte accessType, byte access)
        {
            var setLibraryRightsFunction = new SetLibraryRightsFunction();
                setLibraryRightsFunction.Lib = lib;
                setLibraryRightsFunction.AccessType = accessType;
                setLibraryRightsFunction.Access = access;
            
             return ContractHandler.SendRequestAsync(setLibraryRightsFunction);
        }

        public Task<TransactionReceipt> SetLibraryRightsRequestAndWaitForReceiptAsync(string lib, byte accessType, byte access, CancellationTokenSource cancellationToken = null)
        {
            var setLibraryRightsFunction = new SetLibraryRightsFunction();
                setLibraryRightsFunction.Lib = lib;
                setLibraryRightsFunction.AccessType = accessType;
                setLibraryRightsFunction.Access = access;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setLibraryRightsFunction, cancellationToken);
        }

        public Task<bool> CheckRightsQueryAsync(CheckRightsFunction checkRightsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CheckRightsFunction, bool>(checkRightsFunction, blockParameter);
        }

        
        public Task<bool> CheckRightsQueryAsync(byte indexType, string obj, byte accessType, BlockParameter blockParameter = null)
        {
            var checkRightsFunction = new CheckRightsFunction();
                checkRightsFunction.IndexType = indexType;
                checkRightsFunction.Obj = obj;
                checkRightsFunction.AccessType = accessType;
            
            return ContractHandler.QueryAsync<CheckRightsFunction, bool>(checkRightsFunction, blockParameter);
        }

        public Task<byte> AccessNoneQueryAsync(AccessNoneFunction accessNoneFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AccessNoneFunction, byte>(accessNoneFunction, blockParameter);
        }

        
        public Task<byte> AccessNoneQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AccessNoneFunction, byte>(null, blockParameter);
        }

        public Task<string> CleanUpContentTypesRequestAsync(CleanUpContentTypesFunction cleanUpContentTypesFunction)
        {
             return ContractHandler.SendRequestAsync(cleanUpContentTypesFunction);
        }

        public Task<string> CleanUpContentTypesRequestAsync()
        {
             return ContractHandler.SendRequestAsync<CleanUpContentTypesFunction>();
        }

        public Task<TransactionReceipt> CleanUpContentTypesRequestAndWaitForReceiptAsync(CleanUpContentTypesFunction cleanUpContentTypesFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cleanUpContentTypesFunction, cancellationToken);
        }

        public Task<TransactionReceipt> CleanUpContentTypesRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<CleanUpContentTypesFunction>(null, cancellationToken);
        }

        public Task<string> SetContentTypeRightsRequestAsync(SetContentTypeRightsFunction setContentTypeRightsFunction)
        {
             return ContractHandler.SendRequestAsync(setContentTypeRightsFunction);
        }

        public Task<TransactionReceipt> SetContentTypeRightsRequestAndWaitForReceiptAsync(SetContentTypeRightsFunction setContentTypeRightsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContentTypeRightsFunction, cancellationToken);
        }

        public Task<string> SetContentTypeRightsRequestAsync(string obj, byte accessType, byte access)
        {
            var setContentTypeRightsFunction = new SetContentTypeRightsFunction();
                setContentTypeRightsFunction.Obj = obj;
                setContentTypeRightsFunction.AccessType = accessType;
                setContentTypeRightsFunction.Access = access;
            
             return ContractHandler.SendRequestAsync(setContentTypeRightsFunction);
        }

        public Task<TransactionReceipt> SetContentTypeRightsRequestAndWaitForReceiptAsync(string obj, byte accessType, byte access, CancellationTokenSource cancellationToken = null)
        {
            var setContentTypeRightsFunction = new SetContentTypeRightsFunction();
                setContentTypeRightsFunction.Obj = obj;
                setContentTypeRightsFunction.AccessType = accessType;
                setContentTypeRightsFunction.Access = access;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContentTypeRightsFunction, cancellationToken);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> CleanUpLibrariesRequestAsync(CleanUpLibrariesFunction cleanUpLibrariesFunction)
        {
             return ContractHandler.SendRequestAsync(cleanUpLibrariesFunction);
        }

        public Task<string> CleanUpLibrariesRequestAsync()
        {
             return ContractHandler.SendRequestAsync<CleanUpLibrariesFunction>();
        }

        public Task<TransactionReceipt> CleanUpLibrariesRequestAndWaitForReceiptAsync(CleanUpLibrariesFunction cleanUpLibrariesFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cleanUpLibrariesFunction, cancellationToken);
        }

        public Task<TransactionReceipt> CleanUpLibrariesRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<CleanUpLibrariesFunction>(null, cancellationToken);
        }

        public Task<byte> TypeSeeQueryAsync(TypeSeeFunction typeSeeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TypeSeeFunction, byte>(typeSeeFunction, blockParameter);
        }

        
        public Task<byte> TypeSeeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TypeSeeFunction, byte>(null, blockParameter);
        }

        public Task<ContentTypesOutputDTO> ContentTypesQueryAsync(ContentTypesFunction contentTypesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ContentTypesFunction, ContentTypesOutputDTO>(contentTypesFunction, blockParameter);
        }

        public Task<ContentTypesOutputDTO> ContentTypesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ContentTypesFunction, ContentTypesOutputDTO>(null, blockParameter);
        }

        public Task<bool> CheckDirectRightsQueryAsync(CheckDirectRightsFunction checkDirectRightsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CheckDirectRightsFunction, bool>(checkDirectRightsFunction, blockParameter);
        }

        
        public Task<bool> CheckDirectRightsQueryAsync(byte indexType, string obj, byte accessType, BlockParameter blockParameter = null)
        {
            var checkDirectRightsFunction = new CheckDirectRightsFunction();
                checkDirectRightsFunction.IndexType = indexType;
                checkDirectRightsFunction.Obj = obj;
                checkDirectRightsFunction.AccessType = accessType;
            
            return ContractHandler.QueryAsync<CheckDirectRightsFunction, bool>(checkDirectRightsFunction, blockParameter);
        }

        public Task<byte> GetContentTypeRightsQueryAsync(GetContentTypeRightsFunction getContentTypeRightsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetContentTypeRightsFunction, byte>(getContentTypeRightsFunction, blockParameter);
        }

        
        public Task<byte> GetContentTypeRightsQueryAsync(string obj, BlockParameter blockParameter = null)
        {
            var getContentTypeRightsFunction = new GetContentTypeRightsFunction();
                getContentTypeRightsFunction.Obj = obj;
            
            return ContractHandler.QueryAsync<GetContentTypeRightsFunction, byte>(getContentTypeRightsFunction, blockParameter);
        }

        public Task<bool> CheckContractRightsQueryAsync(CheckContractRightsFunction checkContractRightsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CheckContractRightsFunction, bool>(checkContractRightsFunction, blockParameter);
        }

        
        public Task<bool> CheckContractRightsQueryAsync(string obj, byte accessType, BlockParameter blockParameter = null)
        {
            var checkContractRightsFunction = new CheckContractRightsFunction();
                checkContractRightsFunction.Obj = obj;
                checkContractRightsFunction.AccessType = accessType;
            
            return ContractHandler.QueryAsync<CheckContractRightsFunction, bool>(checkContractRightsFunction, blockParameter);
        }

        public Task<ContentObjectsOutputDTO> ContentObjectsQueryAsync(ContentObjectsFunction contentObjectsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ContentObjectsFunction, ContentObjectsOutputDTO>(contentObjectsFunction, blockParameter);
        }

        public Task<ContentObjectsOutputDTO> ContentObjectsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ContentObjectsFunction, ContentObjectsOutputDTO>(null, blockParameter);
        }

        public Task<string> GetContentTypeQueryAsync(GetContentTypeFunction getContentTypeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetContentTypeFunction, string>(getContentTypeFunction, blockParameter);
        }

        
        public Task<string> GetContentTypeQueryAsync(BigInteger position, BlockParameter blockParameter = null)
        {
            var getContentTypeFunction = new GetContentTypeFunction();
                getContentTypeFunction.Position = position;
            
            return ContractHandler.QueryAsync<GetContentTypeFunction, string>(getContentTypeFunction, blockParameter);
        }

        public Task<string> ContentSpaceQueryAsync(ContentSpaceFunction contentSpaceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContentSpaceFunction, string>(contentSpaceFunction, blockParameter);
        }

        
        public Task<string> ContentSpaceQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContentSpaceFunction, string>(null, blockParameter);
        }

        public Task<string> SetAccessRightsRequestAsync(SetAccessRightsFunction setAccessRightsFunction)
        {
             return ContractHandler.SendRequestAsync(setAccessRightsFunction);
        }

        public Task<string> SetAccessRightsRequestAsync()
        {
             return ContractHandler.SendRequestAsync<SetAccessRightsFunction>();
        }

        public Task<TransactionReceipt> SetAccessRightsRequestAndWaitForReceiptAsync(SetAccessRightsFunction setAccessRightsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAccessRightsFunction, cancellationToken);
        }

        public Task<TransactionReceipt> SetAccessRightsRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<SetAccessRightsFunction>(null, cancellationToken);
        }

        public Task<LibrariesOutputDTO> LibrariesQueryAsync(LibrariesFunction librariesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<LibrariesFunction, LibrariesOutputDTO>(librariesFunction, blockParameter);
        }

        public Task<LibrariesOutputDTO> LibrariesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<LibrariesFunction, LibrariesOutputDTO>(null, blockParameter);
        }

        public Task<BigInteger> GetLibrariesLengthQueryAsync(GetLibrariesLengthFunction getLibrariesLengthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetLibrariesLengthFunction, BigInteger>(getLibrariesLengthFunction, blockParameter);
        }

        
        public Task<BigInteger> GetLibrariesLengthQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetLibrariesLengthFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> GetContentObjectQueryAsync(GetContentObjectFunction getContentObjectFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetContentObjectFunction, string>(getContentObjectFunction, blockParameter);
        }

        
        public Task<string> GetContentObjectQueryAsync(BigInteger position, BlockParameter blockParameter = null)
        {
            var getContentObjectFunction = new GetContentObjectFunction();
                getContentObjectFunction.Position = position;
            
            return ContractHandler.QueryAsync<GetContentObjectFunction, string>(getContentObjectFunction, blockParameter);
        }

        public Task<string> GetLibraryQueryAsync(GetLibraryFunction getLibraryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetLibraryFunction, string>(getLibraryFunction, blockParameter);
        }

        
        public Task<string> GetLibraryQueryAsync(BigInteger position, BlockParameter blockParameter = null)
        {
            var getLibraryFunction = new GetLibraryFunction();
                getLibraryFunction.Position = position;
            
            return ContractHandler.QueryAsync<GetLibraryFunction, string>(getLibraryFunction, blockParameter);
        }

        public Task<byte> TypeAccessQueryAsync(TypeAccessFunction typeAccessFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TypeAccessFunction, byte>(typeAccessFunction, blockParameter);
        }

        
        public Task<byte> TypeAccessQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TypeAccessFunction, byte>(null, blockParameter);
        }

        public Task<string> CleanUpAccessGroupsRequestAsync(CleanUpAccessGroupsFunction cleanUpAccessGroupsFunction)
        {
             return ContractHandler.SendRequestAsync(cleanUpAccessGroupsFunction);
        }

        public Task<string> CleanUpAccessGroupsRequestAsync()
        {
             return ContractHandler.SendRequestAsync<CleanUpAccessGroupsFunction>();
        }

        public Task<TransactionReceipt> CleanUpAccessGroupsRequestAndWaitForReceiptAsync(CleanUpAccessGroupsFunction cleanUpAccessGroupsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(cleanUpAccessGroupsFunction, cancellationToken);
        }

        public Task<TransactionReceipt> CleanUpAccessGroupsRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<CleanUpAccessGroupsFunction>(null, cancellationToken);
        }

        public Task<BigInteger> GetContentObjectsLengthQueryAsync(GetContentObjectsLengthFunction getContentObjectsLengthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetContentObjectsLengthFunction, BigInteger>(getContentObjectsLengthFunction, blockParameter);
        }

        
        public Task<BigInteger> GetContentObjectsLengthQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetContentObjectsLengthFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> SetAccessGroupRightsRequestAsync(SetAccessGroupRightsFunction setAccessGroupRightsFunction)
        {
             return ContractHandler.SendRequestAsync(setAccessGroupRightsFunction);
        }

        public Task<TransactionReceipt> SetAccessGroupRightsRequestAndWaitForReceiptAsync(SetAccessGroupRightsFunction setAccessGroupRightsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAccessGroupRightsFunction, cancellationToken);
        }

        public Task<string> SetAccessGroupRightsRequestAsync(string group, byte accessType, byte access)
        {
            var setAccessGroupRightsFunction = new SetAccessGroupRightsFunction();
                setAccessGroupRightsFunction.Group = group;
                setAccessGroupRightsFunction.AccessType = accessType;
                setAccessGroupRightsFunction.Access = access;
            
             return ContractHandler.SendRequestAsync(setAccessGroupRightsFunction);
        }

        public Task<TransactionReceipt> SetAccessGroupRightsRequestAndWaitForReceiptAsync(string group, byte accessType, byte access, CancellationTokenSource cancellationToken = null)
        {
            var setAccessGroupRightsFunction = new SetAccessGroupRightsFunction();
                setAccessGroupRightsFunction.Group = group;
                setAccessGroupRightsFunction.AccessType = accessType;
                setAccessGroupRightsFunction.Access = access;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAccessGroupRightsFunction, cancellationToken);
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

        public Task<byte> GetLibraryRightsQueryAsync(GetLibraryRightsFunction getLibraryRightsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetLibraryRightsFunction, byte>(getLibraryRightsFunction, blockParameter);
        }

        
        public Task<byte> GetLibraryRightsQueryAsync(string lib, BlockParameter blockParameter = null)
        {
            var getLibraryRightsFunction = new GetLibraryRightsFunction();
                getLibraryRightsFunction.Lib = lib;
            
            return ContractHandler.QueryAsync<GetLibraryRightsFunction, byte>(getLibraryRightsFunction, blockParameter);
        }

        public Task<BigInteger> GetContractsLengthQueryAsync(GetContractsLengthFunction getContractsLengthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetContractsLengthFunction, BigInteger>(getContractsLengthFunction, blockParameter);
        }

        
        public Task<BigInteger> GetContractsLengthQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetContractsLengthFunction, BigInteger>(null, blockParameter);
        }

        public Task<bool> CheckContentTypeRightsQueryAsync(CheckContentTypeRightsFunction checkContentTypeRightsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CheckContentTypeRightsFunction, bool>(checkContentTypeRightsFunction, blockParameter);
        }

        
        public Task<bool> CheckContentTypeRightsQueryAsync(string obj, byte accessType, BlockParameter blockParameter = null)
        {
            var checkContentTypeRightsFunction = new CheckContentTypeRightsFunction();
                checkContentTypeRightsFunction.Obj = obj;
                checkContentTypeRightsFunction.AccessType = accessType;
            
            return ContractHandler.QueryAsync<CheckContentTypeRightsFunction, bool>(checkContentTypeRightsFunction, blockParameter);
        }
    }
}
