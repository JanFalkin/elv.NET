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
using Elv.NET.Contracts.Accessible.ContractDefinition;

namespace Elv.NET.Contracts.Accessible
{
    public partial class AccessibleService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, AccessibleDeployment accessibleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<AccessibleDeployment>().SendRequestAndWaitForReceiptAsync(accessibleDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, AccessibleDeployment accessibleDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<AccessibleDeployment>().SendRequestAsync(accessibleDeployment);
        }

        public static async Task<AccessibleService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, AccessibleDeployment accessibleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, accessibleDeployment, cancellationTokenSource);
            return new AccessibleService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public AccessibleService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public AccessibleService(Nethereum.Web3.IWeb3 web3, string contractAddress)
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

        public Task<byte> CanSeeQueryAsync(CanSeeFunction canSeeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanSeeFunction, byte>(canSeeFunction, blockParameter);
        }

        
        public Task<byte> CanSeeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanSeeFunction, byte>(null, blockParameter);
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

        public Task<byte> VisibilityQueryAsync(VisibilityFunction visibilityFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VisibilityFunction, byte>(visibilityFunction, blockParameter);
        }

        
        public Task<byte> VisibilityQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VisibilityFunction, byte>(null, blockParameter);
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

        public Task<byte> IndexCategoryQueryAsync(IndexCategoryFunction indexCategoryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IndexCategoryFunction, byte>(indexCategoryFunction, blockParameter);
        }

        
        public Task<byte> IndexCategoryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IndexCategoryFunction, byte>(null, blockParameter);
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

        public Task<byte> CanEditQueryAsync(CanEditFunction canEditFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanEditFunction, byte>(canEditFunction, blockParameter);
        }

        
        public Task<byte> CanEditQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CanEditFunction, byte>(null, blockParameter);
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
