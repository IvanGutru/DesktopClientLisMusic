/**
 * Autogenerated by Thrift Compiler (0.13.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Thrift;
using Thrift.Collections;

using Thrift.Protocol;
using Thrift.Protocol.Entities;
using Thrift.Protocol.Utilities;
using Thrift.Transport;
using Thrift.Transport.Client;
using Thrift.Transport.Server;
using Thrift.Processor;



public partial class TrackRequest : TBase
{
  private string _fileName;
  private Quality _quality;

  public string FileName
  {
    get
    {
      return _fileName;
    }
    set
    {
      __isset.fileName = true;
      this._fileName = value;
    }
  }

  /// <summary>
  /// 
  /// <seealso cref="Quality"/>
  /// </summary>
  public Quality Quality
  {
    get
    {
      return _quality;
    }
    set
    {
      __isset.quality = true;
      this._quality = value;
    }
  }


  public Isset __isset;
  public struct Isset
  {
    public bool fileName;
    public bool quality;
  }

  public TrackRequest()
  {
  }

  public async Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      TField field;
      await iprot.ReadStructBeginAsync(cancellationToken);
      while (true)
      {
        field = await iprot.ReadFieldBeginAsync(cancellationToken);
        if (field.Type == TType.Stop)
        {
          break;
        }

        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.String)
            {
              FileName = await iprot.ReadStringAsync(cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          case 2:
            if (field.Type == TType.I32)
            {
              Quality = (Quality)await iprot.ReadI32Async(cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          default: 
            await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            break;
        }

        await iprot.ReadFieldEndAsync(cancellationToken);
      }

      await iprot.ReadStructEndAsync(cancellationToken);
    }
    finally
    {
      iprot.DecrementRecursionDepth();
    }
  }

  public async Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
  {
    oprot.IncrementRecursionDepth();
    try
    {
      var struc = new TStruct("TrackRequest");
      await oprot.WriteStructBeginAsync(struc, cancellationToken);
      var field = new TField();
      if (FileName != null && __isset.fileName)
      {
        field.Name = "fileName";
        field.Type = TType.String;
        field.ID = 1;
        await oprot.WriteFieldBeginAsync(field, cancellationToken);
        await oprot.WriteStringAsync(FileName, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      if (__isset.quality)
      {
        field.Name = "quality";
        field.Type = TType.I32;
        field.ID = 2;
        await oprot.WriteFieldBeginAsync(field, cancellationToken);
        await oprot.WriteI32Async((int)Quality, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      await oprot.WriteFieldStopAsync(cancellationToken);
      await oprot.WriteStructEndAsync(cancellationToken);
    }
    finally
    {
      oprot.DecrementRecursionDepth();
    }
  }

  public override bool Equals(object that)
  {
    var other = that as TrackRequest;
    if (other == null) return false;
    if (ReferenceEquals(this, other)) return true;
    return ((__isset.fileName == other.__isset.fileName) && ((!__isset.fileName) || (System.Object.Equals(FileName, other.FileName))))
      && ((__isset.quality == other.__isset.quality) && ((!__isset.quality) || (System.Object.Equals(Quality, other.Quality))));
  }

  public override int GetHashCode() {
    int hashcode = 157;
    unchecked {
      if(__isset.fileName)
        hashcode = (hashcode * 397) + FileName.GetHashCode();
      if(__isset.quality)
        hashcode = (hashcode * 397) + Quality.GetHashCode();
    }
    return hashcode;
  }

  public override string ToString()
  {
    var sb = new StringBuilder("TrackRequest(");
    bool __first = true;
    if (FileName != null && __isset.fileName)
    {
      if(!__first) { sb.Append(", "); }
      __first = false;
      sb.Append("FileName: ");
      sb.Append(FileName);
    }
    if (__isset.quality)
    {
      if(!__first) { sb.Append(", "); }
      __first = false;
      sb.Append("Quality: ");
      sb.Append(Quality);
    }
    sb.Append(")");
    return sb.ToString();
  }
}

