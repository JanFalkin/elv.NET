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

namespace Elv.NET.Contracts.Adminable.ContractDefinition
{


    public partial class AdminableDeployment : AdminableDeploymentBase
    {
        public AdminableDeployment() : base(BYTECODE) { }
        public AdminableDeployment(string byteCode) : base(byteCode) { }
    }

    public class AdminableDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public AdminableDeploymentBase() : base(BYTECODE) { }
        public AdminableDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class CreatorFunction : CreatorFunctionBase { }

    [Function("creator", "address")]
    public class CreatorFunctionBase : FunctionMessage
    {

    }

    public partial class IsAdminFunction : IsAdminFunctionBase { }

    [Function("isAdmin", "bool")]
    public class IsAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "_candidate", 1)]
        public virtual string Candidate { get; set; }
    }

    public partial class KillFunction : KillFunctionBase { }

    [Function("kill")]
    public class KillFunctionBase : FunctionMessage
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

    public partial class IsAdminOutputDTO : IsAdminOutputDTOBase { }

    [FunctionOutput]
    public class IsAdminOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
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
