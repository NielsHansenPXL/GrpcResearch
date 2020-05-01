// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/artists.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcServer.Protos {
  public static partial class RemoteArtist
  {
    static readonly string __ServiceName = "RemoteArtist";

    static readonly grpc::Marshaller<global::GrpcServer.Protos.ArtistLookUpModel> __Marshaller_ArtistLookUpModel = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcServer.Protos.ArtistLookUpModel.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::GrpcServer.Protos.ArtistModel> __Marshaller_ArtistModel = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::GrpcServer.Protos.ArtistModel.Parser.ParseFrom);

    static readonly grpc::Method<global::GrpcServer.Protos.ArtistLookUpModel, global::GrpcServer.Protos.ArtistModel> __Method_GetArtistInfo = new grpc::Method<global::GrpcServer.Protos.ArtistLookUpModel, global::GrpcServer.Protos.ArtistModel>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetArtistInfo",
        __Marshaller_ArtistLookUpModel,
        __Marshaller_ArtistModel);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcServer.Protos.ArtistsReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of RemoteArtist</summary>
    [grpc::BindServiceMethod(typeof(RemoteArtist), "BindService")]
    public abstract partial class RemoteArtistBase
    {
      public virtual global::System.Threading.Tasks.Task<global::GrpcServer.Protos.ArtistModel> GetArtistInfo(global::GrpcServer.Protos.ArtistLookUpModel request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(RemoteArtistBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_GetArtistInfo, serviceImpl.GetArtistInfo).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, RemoteArtistBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_GetArtistInfo, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcServer.Protos.ArtistLookUpModel, global::GrpcServer.Protos.ArtistModel>(serviceImpl.GetArtistInfo));
    }

  }
}
#endregion