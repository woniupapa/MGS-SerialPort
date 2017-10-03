﻿# MGS-SerialPort
- [中文手册](./README_ZH.md)

## Summary
- Unity communicate with serialport.

## Demand
- Serialport synchronous read and write data; parameters of serialport config in local file.

## Environment
- Unity 5.0 or above.
- .Net Framework 2.0(Set the "Api Compatibility Level" as ".NET 2.0". Find in the path
  "Build Settings -> Player Settings -> Other Settings").

## Issue
- Current Unity can not read serialport data in "Update" or "FixedUpdate" method.
- Current Unity not implemented the "SerialPort.ReceivedBytesThreshold" property.
- Current Unity can not callback the "SerialPort.DataReceived" event.
- Current Unity can not read the "SerialPort.BytesToRead" property.
- Current Unity can not execute the "SerialPort.DiscardInBuffer" method effectively.
- Current Unity can not execute the "SerialPort.DiscardOutBuffer" method effectively.

## Achieve
- SerialPortConfig : Config of serialport parameters.
- SerialPortConfigurer : Read config from local file and write config to file.
- SerialPortController : Synchronous read and write serialport data.

## Demo
- Demos in the path "MGS-SerialPort\Scenes" provide reference to you.

## Preview
- Serialport Write And Read

![SerialPortConfig](./Attachments/SerialportWriteAndRead.png)

## Contact
- If you have anny questions, fell free to contact me at mogoson@qq.com.