namespace MsdnTableParser

module LocalFileFetcher =
    open System.Text
    open System.Threading.Tasks

    val fetchFileAsync : encoding:Encoding -> path:string -> Task<option<string>>
