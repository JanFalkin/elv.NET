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

namespace Elv.NET.Contracts.BaseContentFactory.ContractDefinition
{


    public partial class BaseContentFactoryDeployment : BaseContentFactoryDeploymentBase
    {
        public BaseContentFactoryDeployment() : base(BYTECODE) { }
        public BaseContentFactoryDeployment(string byteCode) : base(byteCode) { }
    }

    public class BaseContentFactoryDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public BaseContentFactoryDeploymentBase() : base(BYTECODE) { }
        public BaseContentFactoryDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_spaceAddr", 1)]
        public virtual string SpaceAddr { get; set; }
        [Parameter("address", "_helperAddr", 2)]
        public virtual string HelperAddr { get; set; }
    }

    public partial class CreatorFunction : CreatorFunctionBase { }

    [Function("creator", "address")]
    public class CreatorFunctionBase : FunctionMessage
    {

    }

    public partial class IsContractFunction : IsContractFunctionBase { }

    [Function("isContract", "bool")]
    public class IsContractFunctionBase : FunctionMessage
    {
        [Parameter("address", "addr", 1)]
        public virtual string Addr { get; set; }
    }

    public partial class KillFunction : KillFunctionBase { }

    [Function("kill")]
    public class KillFunctionBase : FunctionMessage
    {

    }

    public partial class OpAccessCompleteFunction : OpAccessCompleteFunctionBase { }

    [Function("OP_ACCESS_COMPLETE", "uint32")]
    public class OpAccessCompleteFunctionBase : FunctionMessage
    {

    }

    public partial class ExecuteAccessBatchFunction : ExecuteAccessBatchFunctionBase { }

    [Function("executeAccessBatch")]
    public class ExecuteAccessBatchFunctionBase : FunctionMessage
    {
        [Parameter("uint32[]", "_opCodes", 1)]
        public virtual List<uint> OpCodes { get; set; }
        [Parameter("address[]", "_contentAddrs", 2)]
        public virtual List<string> ContentAddrs { get; set; }
        [Parameter("address[]", "_userAddrs", 3)]
        public virtual List<string> UserAddrs { get; set; }
        [Parameter("uint256[]", "_requestNonces", 4)]
        public virtual List<BigInteger> RequestNonces { get; set; }
        [Parameter("bytes32[]", "_ctxHashes", 5)]
        public virtual List<byte[]> CtxHashes { get; set; }
        [Parameter("uint256[]", "_ts", 6)]
        public virtual List<BigInteger> Ts { get; set; }
        [Parameter("uint256[]", "", 7)]
        public virtual List<BigInteger> ReturnValue7 { get; set; }
    }

    public partial class OpAccessRequestFunction : OpAccessRequestFunctionBase { }

    [Function("OP_ACCESS_REQUEST", "uint32")]
    public class OpAccessRequestFunctionBase : FunctionMessage
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

    public partial class TransferCreatorshipFunction : TransferCreatorshipFunctionBase { }

    [Function("transferCreatorship")]
    public class TransferCreatorshipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newCreator", 1)]
        public virtual string NewCreator { get; set; }
    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class ContentSpaceFunction : ContentSpaceFunctionBase { }

    [Function("contentSpace", "address")]
    public class ContentSpaceFunctionBase : FunctionMessage
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

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class CreatorOutputDTO : CreatorOutputDTOBase { }

    [FunctionOutput]
    public class CreatorOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class IsContractOutputDTO : IsContractOutputDTOBase { }

    [FunctionOutput]
    public class IsContractOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }



    public partial class OpAccessCompleteOutputDTO : OpAccessCompleteOutputDTOBase { }

    [FunctionOutput]
    public class OpAccessCompleteOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint32", "", 1)]
        public virtual uint ReturnValue1 { get; set; }
    }



    public partial class OpAccessRequestOutputDTO : OpAccessRequestOutputDTOBase { }

    [FunctionOutput]
    public class OpAccessRequestOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint32", "", 1)]
        public virtual uint ReturnValue1 { get; set; }
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



    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class ContentSpaceOutputDTO : ContentSpaceOutputDTOBase { }

    [FunctionOutput]
    public class ContentSpaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }




}
