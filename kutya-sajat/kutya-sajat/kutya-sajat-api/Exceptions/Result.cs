﻿using System;

namespace kutya_sajat_api.Exceptions
{
    public readonly struct Result<T, E>
    {
        private readonly bool _success;
        public readonly T Value;
        public readonly E Error;

        private Result(T v, E e, bool success)
        {
            Value = v;
            Error = e;
            _success = success;
        }

        public bool IsOk => _success;

        public static Result<T, E> Ok(T v)
        {
            return new(v, default, true);
        }

        public static Result<T, E> Err(E e)
        {
            return new(default, e, false);
        }

        public static implicit operator Result<T, E>(T v) => new(v, default, true);
        public static implicit operator Result<T, E>(E e) => new(default, e, false);

        public R Match<R>(
                Func<T, R> success,
                Func<E, R> failure) =>
            _success ? success(Value) : failure(Error);
    }
}
