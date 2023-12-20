﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Core.DTOs
{
    public class CustomResponseDto<T>
    {
        public T? Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }

        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> {StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<string> error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = error };
        }

        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors =new List<string> { error } };
        }

        public static CustomResponseDto<T> CreateSuccess(int statusCode, T data)
        {
            return new CustomResponseDto<T>
            {
                StatusCode = statusCode,
                Data = data,
                Errors = null
            };
        }

        public static CustomResponseDto<T> CreateSuccess(int statusCode)
        {
            return new CustomResponseDto<T>
            {
                StatusCode = statusCode,
                Data = default(T),
                Errors = null
            };
        }

        public static CustomResponseDto<T> CreateFail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<T>
            {
                StatusCode = statusCode,
                Data = default(T),
                Errors = errors
            };
        }

        public static CustomResponseDto<T> CreateFail(int statusCode, string error)
        {
            return new CustomResponseDto<T>
            {
                StatusCode = statusCode,
                Data = default(T),
                Errors = new List<string> { error }
            };
        }

    }
}
