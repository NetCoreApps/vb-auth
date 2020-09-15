"use strict";
/* Options:
Date: 2020-09-15 18:43:08
Version: 5.93
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: https://localhost:44330

//GlobalNamespace:
//MakePropertiesOptional: False
//AddServiceStackTypes: True
//AddResponseStatus: False
//AddImplicitVersion:
//AddDescriptionAsComments: True
//IncludeTypes:
//ExcludeTypes:
//DefaultImports:
*/
exports.__esModule = true;
exports.GetAccessToken = exports.ConvertSessionToToken = exports.UnAssignRoles = exports.AssignRoles = exports.Authenticate = exports.DeleteFile = exports.DownloadFile = exports.GetUploadedFiles = exports.UploadFile = exports.MyTables = exports.Hello = exports.GetAccessTokenResponse = exports.ConvertSessionToTokenResponse = exports.UnAssignRolesResponse = exports.AssignRolesResponse = exports.AuthenticateResponse = exports.GetUploadedFilesResponse = exports.MyTablesResponse = exports.HelloResponse = exports.ResponseStatus = exports.ResponseError = exports.MyTable = void 0;
var MyTable = /** @class */ (function () {
    function MyTable(init) {
        Object.assign(this, init);
    }
    return MyTable;
}());
exports.MyTable = MyTable;
// @DataContract
var ResponseError = /** @class */ (function () {
    function ResponseError(init) {
        Object.assign(this, init);
    }
    return ResponseError;
}());
exports.ResponseError = ResponseError;
// @DataContract
var ResponseStatus = /** @class */ (function () {
    function ResponseStatus(init) {
        Object.assign(this, init);
    }
    return ResponseStatus;
}());
exports.ResponseStatus = ResponseStatus;
var HelloResponse = /** @class */ (function () {
    function HelloResponse(init) {
        Object.assign(this, init);
    }
    return HelloResponse;
}());
exports.HelloResponse = HelloResponse;
var MyTablesResponse = /** @class */ (function () {
    function MyTablesResponse(init) {
        Object.assign(this, init);
    }
    return MyTablesResponse;
}());
exports.MyTablesResponse = MyTablesResponse;
var GetUploadedFilesResponse = /** @class */ (function () {
    function GetUploadedFilesResponse(init) {
        Object.assign(this, init);
    }
    return GetUploadedFilesResponse;
}());
exports.GetUploadedFilesResponse = GetUploadedFilesResponse;
// @DataContract
var AuthenticateResponse = /** @class */ (function () {
    function AuthenticateResponse(init) {
        Object.assign(this, init);
    }
    return AuthenticateResponse;
}());
exports.AuthenticateResponse = AuthenticateResponse;
// @DataContract
var AssignRolesResponse = /** @class */ (function () {
    function AssignRolesResponse(init) {
        Object.assign(this, init);
    }
    return AssignRolesResponse;
}());
exports.AssignRolesResponse = AssignRolesResponse;
// @DataContract
var UnAssignRolesResponse = /** @class */ (function () {
    function UnAssignRolesResponse(init) {
        Object.assign(this, init);
    }
    return UnAssignRolesResponse;
}());
exports.UnAssignRolesResponse = UnAssignRolesResponse;
// @DataContract
var ConvertSessionToTokenResponse = /** @class */ (function () {
    function ConvertSessionToTokenResponse(init) {
        Object.assign(this, init);
    }
    return ConvertSessionToTokenResponse;
}());
exports.ConvertSessionToTokenResponse = ConvertSessionToTokenResponse;
// @DataContract
var GetAccessTokenResponse = /** @class */ (function () {
    function GetAccessTokenResponse(init) {
        Object.assign(this, init);
    }
    return GetAccessTokenResponse;
}());
exports.GetAccessTokenResponse = GetAccessTokenResponse;
// @Route("/hello")
// @Route("/hello/{Name}")
var Hello = /** @class */ (function () {
    function Hello(init) {
        Object.assign(this, init);
    }
    Hello.prototype.createResponse = function () { return new HelloResponse(); };
    Hello.prototype.getTypeName = function () { return 'Hello'; };
    return Hello;
}());
exports.Hello = Hello;
// @Route("/data")
var MyTables = /** @class */ (function () {
    function MyTables(init) {
        Object.assign(this, init);
    }
    MyTables.prototype.createResponse = function () { return new MyTablesResponse(); };
    MyTables.prototype.getTypeName = function () { return 'MyTables'; };
    return MyTables;
}());
exports.MyTables = MyTables;
// @Route("/uploads")
var UploadFile = /** @class */ (function () {
    function UploadFile(init) {
        Object.assign(this, init);
    }
    UploadFile.prototype.createResponse = function () { };
    UploadFile.prototype.getTypeName = function () { return 'UploadFile'; };
    return UploadFile;
}());
exports.UploadFile = UploadFile;
// @Route("/uploads")
var GetUploadedFiles = /** @class */ (function () {
    function GetUploadedFiles(init) {
        Object.assign(this, init);
    }
    GetUploadedFiles.prototype.createResponse = function () { return new GetUploadedFilesResponse(); };
    GetUploadedFiles.prototype.getTypeName = function () { return 'GetUploadedFiles'; };
    return GetUploadedFiles;
}());
exports.GetUploadedFiles = GetUploadedFiles;
// @Route("/uploads/{Name}")
var DownloadFile = /** @class */ (function () {
    function DownloadFile(init) {
        Object.assign(this, init);
    }
    DownloadFile.prototype.createResponse = function () { return new Uint8Array(0); };
    DownloadFile.prototype.getTypeName = function () { return 'DownloadFile'; };
    return DownloadFile;
}());
exports.DownloadFile = DownloadFile;
// @Route("/uploads/{Name}")
var DeleteFile = /** @class */ (function () {
    function DeleteFile(init) {
        Object.assign(this, init);
    }
    DeleteFile.prototype.createResponse = function () { };
    DeleteFile.prototype.getTypeName = function () { return 'DeleteFile'; };
    return DeleteFile;
}());
exports.DeleteFile = DeleteFile;
// @Route("/auth")
// @Route("/auth/{provider}")
// @DataContract
var Authenticate = /** @class */ (function () {
    function Authenticate(init) {
        Object.assign(this, init);
    }
    Authenticate.prototype.createResponse = function () { return new AuthenticateResponse(); };
    Authenticate.prototype.getTypeName = function () { return 'Authenticate'; };
    return Authenticate;
}());
exports.Authenticate = Authenticate;
// @Route("/assignroles")
// @DataContract
var AssignRoles = /** @class */ (function () {
    function AssignRoles(init) {
        Object.assign(this, init);
    }
    AssignRoles.prototype.createResponse = function () { return new AssignRolesResponse(); };
    AssignRoles.prototype.getTypeName = function () { return 'AssignRoles'; };
    return AssignRoles;
}());
exports.AssignRoles = AssignRoles;
// @Route("/unassignroles")
// @DataContract
var UnAssignRoles = /** @class */ (function () {
    function UnAssignRoles(init) {
        Object.assign(this, init);
    }
    UnAssignRoles.prototype.createResponse = function () { return new UnAssignRolesResponse(); };
    UnAssignRoles.prototype.getTypeName = function () { return 'UnAssignRoles'; };
    return UnAssignRoles;
}());
exports.UnAssignRoles = UnAssignRoles;
// @Route("/session-to-token")
// @DataContract
var ConvertSessionToToken = /** @class */ (function () {
    function ConvertSessionToToken(init) {
        Object.assign(this, init);
    }
    ConvertSessionToToken.prototype.createResponse = function () { return new ConvertSessionToTokenResponse(); };
    ConvertSessionToToken.prototype.getTypeName = function () { return 'ConvertSessionToToken'; };
    return ConvertSessionToToken;
}());
exports.ConvertSessionToToken = ConvertSessionToToken;
// @Route("/access-token")
// @DataContract
var GetAccessToken = /** @class */ (function () {
    function GetAccessToken(init) {
        Object.assign(this, init);
    }
    GetAccessToken.prototype.createResponse = function () { return new GetAccessTokenResponse(); };
    GetAccessToken.prototype.getTypeName = function () { return 'GetAccessToken'; };
    return GetAccessToken;
}());
exports.GetAccessToken = GetAccessToken;
