﻿namespace GWallet.Backend.Tests

open System
open System.Numerics
open System.Reflection

open NUnit.Framework
open Newtonsoft.Json

open GWallet.Backend

module Serialization =
    let version = Assembly.GetExecutingAssembly().GetName().Version.ToString()

    [<Test>]
    let ``basic caching export does not fail``() =
        let json = Caching.ExportToJson MarshallingData.EmptyCachingDataExample
        Assert.That(json, Is.Not.Null)
        Assert.That(json, Is.Not.Empty)

    [<Test>]
    let ``basic caching export is accurate``() =
        let json = Caching.ExportToJson MarshallingData.EmptyCachingDataExample
        Assert.That(json, Is.Not.Null)
        Assert.That(json, Is.Not.Empty)
        Assert.That(json, Is.EqualTo (MarshallingData.EmptyCachingDataExampleInJson))

    [<Test>]
    let ``complex caching export works``() =

        let json = Caching.ExportToJson MarshallingData.SofisticatedCachindDataExample
        Assert.That(json, Is.Not.Null)
        Assert.That(json, Is.Not.Empty)

        Assert.That(json,
                    Is.EqualTo (MarshallingData.SofisticatedCachingDataExampleInJson))

    [<Test>]
    let ``unsigned transaction export``() =
        let json = Account.ExportUnsignedTransactionToJson
                               MarshallingData.UnsignedTransactionExample
        Assert.That(json, Is.Not.Null)
        Assert.That(json, Is.Not.Empty)
        Assert.That(json,
                    Is.EqualTo(MarshallingData.UnsignedTransactionExampleInJson))

    [<Test>]
    let ``signed transaction export``() =
        let json = Account.ExportUnsignedTransactionToJson MarshallingData.SignedTransactionExample
        Assert.That(json, Is.Not.Null)
        Assert.That(json, Is.Not.Empty)
        Assert.That(json, Is.EqualTo (MarshallingData.SignedTransactionExampleInJson))