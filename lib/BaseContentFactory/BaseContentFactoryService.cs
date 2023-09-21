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
using Elv.NET.Contracts.BaseContentFactory.ContractDefinition;

namespace Elv.NET.Contracts.BaseContentFactory
{
    public partial class BaseContentFactoryService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, BaseContentFactoryDeployment baseContentFactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<BaseContentFactoryDeployment>().SendRequestAndWaitForReceiptAsync(baseContentFactoryDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, BaseContentFactoryDeployment baseContentFactoryDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<BaseContentFactoryDeployment>().SendRequestAsync(baseContentFactoryDeployment);
        }

        public static async Task<BaseContentFactoryService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, BaseContentFactoryDeployment baseContentFactoryDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, baseContentFactoryDeployment, cancellationTokenSource);
            return new BaseContentFactoryService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public BaseContentFactoryService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public BaseContentFactoryService(Nethereum.Web3.IWeb3 web3, string contractAddress)
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

        public Task<bool> IsContractQueryAsync(IsContractFunction isContractFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsContractFunction, bool>(isContractFunction, blockParameter);
        }

        
        public Task<bool> IsContractQueryAsync(string addr, BlockParameter blockParameter = null)
        {
            var isContractFunction = new IsContractFunction();
                isContractFunction.Addr = addr;
            
            return ContractHandler.QueryAsync<IsContractFunction, bool>(isContractFunction, blockParameter);
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

        public Task<uint> OpAccessCompleteQueryAsync(OpAccessCompleteFunction opAccessCompleteFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OpAccessCompleteFunction, uint>(opAccessCompleteFunction, blockParameter);
        }

        
        public Task<uint> OpAccessCompleteQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OpAccessCompleteFunction, uint>(null, blockParameter);
        }

        public Task<string> ExecuteAccessBatchRequestAsync(ExecuteAccessBatchFunction executeAccessBatchFunction)
        {
             return ContractHandler.SendRequestAsync(executeAccessBatchFunction);
        }

        public Task<TransactionReceipt> ExecuteAccessBatchRequestAndWaitForReceiptAsync(ExecuteAccessBatchFunction executeAccessBatchFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(executeAccessBatchFunction, cancellationToken);
        }

        public Task<string> ExecuteAccessBatchRequestAsync(List<uint> opCodes, List<string> contentAddrs, List<string> userAddrs, List<BigInteger> requestNonces, List<byte[]> ctxHashes, List<BigInteger> ts, List<BigInteger> returnValue7)
        {
            var executeAccessBatchFunction = new ExecuteAccessBatchFunction();
                executeAccessBatchFunction.OpCodes = opCodes;
                executeAccessBatchFunction.ContentAddrs = contentAddrs;
                executeAccessBatchFunction.UserAddrs = userAddrs;
                executeAccessBatchFunction.RequestNonces = requestNonces;
                executeAccessBatchFunction.CtxHashes = ctxHashes;
                executeAccessBatchFunction.Ts = ts;
                executeAccessBatchFunction.ReturnValue7 = returnValue7;
            
             return ContractHandler.SendRequestAsync(executeAccessBatchFunction);
        }

        public Task<TransactionReceipt> ExecuteAccessBatchRequestAndWaitForReceiptAsync(List<uint> opCodes, List<string> contentAddrs, List<string> userAddrs, List<BigInteger> requestNonces, List<byte[]> ctxHashes, List<BigInteger> ts, List<BigInteger> returnValue7, CancellationTokenSource cancellationToken = null)
        {
            var executeAccessBatchFunction = new ExecuteAccessBatchFunction();
                executeAccessBatchFunction.OpCodes = opCodes;
                executeAccessBatchFunction.ContentAddrs = contentAddrs;
                executeAccessBatchFunction.UserAddrs = userAddrs;
                executeAccessBatchFunction.RequestNonces = requestNonces;
                executeAccessBatchFunction.CtxHashes = ctxHashes;
                executeAccessBatchFunction.Ts = ts;
                executeAccessBatchFunction.ReturnValue7 = returnValue7;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(executeAccessBatchFunction, cancellationToken);
        }

        public Task<uint> OpAccessRequestQueryAsync(OpAccessRequestFunction opAccessRequestFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OpAccessRequestFunction, uint>(opAccessRequestFunction, blockParameter);
        }

        
        public Task<uint> OpAccessRequestQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OpAccessRequestFunction, uint>(null, blockParameter);
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

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> ContentSpaceQueryAsync(ContentSpaceFunction contentSpaceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContentSpaceFunction, string>(contentSpaceFunction, blockParameter);
        }

        
        public Task<string> ContentSpaceQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContentSpaceFunction, string>(null, blockParameter);
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
