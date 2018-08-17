extern crate libc;
use std::ffi::{CStr};

#[no_mangle]
pub extern "C" fn rust_string(_num: i32) -> *const u8 {
    let str_num = "hello rust:".to_owned()+&_num.to_string()+"\0";
    return str_num.as_ptr();
}

#[no_mangle]
pub extern "C" fn rust_string_arg(param: *const u8) -> *const u8{
    let cstr = unsafe {CStr::from_ptr(param as *const _)}.to_string_lossy(); 
    let str_param = cstr.to_string()+"\0";
    return str_param.as_ptr();
}

#[no_mangle]
pub extern "C" fn rust_string_array() -> *const *const u8{
    let v = vec![
        "Hello\0".as_ptr(),
        "Rust\0".as_ptr(),
        "Unity\0".as_ptr()
    ];
    let p = v.as_ptr();
    std::mem::forget(v);
    p
}

#[no_mangle]
pub extern "C" fn rust_mul(_num1: i32, _num2: i32) -> i32 {
    let res = _num1*_num2;
    return res;
}

#[no_mangle]
pub extern "C" fn rust_bool(_num: i32) -> bool {
    if _num < 0{
        return false;
    }
    return true;
}