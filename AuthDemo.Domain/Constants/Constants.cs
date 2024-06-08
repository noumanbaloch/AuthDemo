namespace AuthDemo.Domain.Constants;

public struct ApiStatusCodes
{
    // 100 series for failures
    public const short RECORD_ALREADY_EXIST = 100;
    public const short INVALID_USERNAME_OR_PASSWORD = 101;
    public const short INVALID_VERIFICATION_CODE = 102;
    public const short UNABLE_TO_COMPLETE_PROCESS = 103;
    public const short USER_ALREADY_EXIST = 105;
    public const short PASSWORD_NOT_CHANGED = 106;
    public const short SOMETHING_WENT_WRONG = 107;
    public const short RECORD_NOT_FOUND = 108;
    public const short USER_DOES_NOT_EXIST = 109;
    public const short PASSWORD_IS_INVALID = 111;
    public const short UNSUPPORTED_IMAGE_TYPE = 112;

    // 200 series for success
    public const short RECORD_SAVED_SUCCESSFULLY = 200;
    public const short USER_LOGIN_SUCCESSFULLY = 201;
    public const short VERIFICATION_CODE_SENT = 202;
    public const short OTP_VERIFIED_SUCCESSFULLY = 203;
    public const short PASSWORD_CHANGED = 204;
    public const short RECORD_FOUND = 205;
    public const short REQUEST_COMPLETED_SUCCESSFULLY = 206;
    public const short PROFILE_UPDATED_SUCCESSFULLY = 207;
    public const short CARD_REPORTED_SUCCESSFULLY = 208;
    public const short WELCOME_MESSAGE = 209;
    public const short WELCOME_BACK_MESSAGE = 210;
}

public struct ApiResponseMessages
{
    public const string RECORD_ALREADY_EXIST = "Record already exists.";
    public const string RECORD_SAVED_SUCCESSFULLY = "Record saved successfully.";
    public const string INVALID_USERNAME_OR_PASSWORD = "Invalid username or password.";
    public const string USER_LOGIN_SUCCESSFULLY = "User logged in successfully.";
    public const string INVALID_VERIFICATION_CODE = "Invalid verification code.";
    public const string USER_ALREADY_EXIST = "User already exists.";
    public const string UNABLE_TO_COMPLETE_PROCESS = "Unable to complete the requested process.";
    public const string VERIFICATION_CODE_SENT = "Verification Code Sent! Please check your inbox and spam folder.";
    public const string OTP_VERIFIED_SUCCESSFULLY = "OTP verified successfully.";
    public const string PASSWORD_CHANGED = "Password changed successfully.";
    public const string PASSWORD_NOT_CHANGED = "Password not changed.";
    public const string SOMETHING_WENT_WRONG = "Something went wrong.";
    public const string RECORD_FOUND = "Record found.";
    public const string RECORD_NOT_FOUND = "Record not found.";
    public const string USER_DOES_NOT_EXIST = "User does not exist.";
    public const string REQUEST_COMPLETED_SUCCESSFULLY = "Request completed successfully.";
    public const string PROFILE_UPDATED_SUCCESSFULLY = "Profile updated successfully.";
    public const string WELCOME_MESSAGE = "Welcome, ";
    public const string WELCOME_BACK_MESSAGE = "Welcome back, ";
    public const string PASSWORD_IS_INVALID = "Password is invalid.";
    public const string UNSUPPORTED_IMAGE_TYPE = "Unsupported file type. Use .jpg, .jpeg, or .png.";
}

public struct Usernames
{
    public const string SYSTEM_USERNAME = "AuthDemoFrameWork";
}

public struct MagicNumbers
{
    public const short OTP_LENGTH = 4;
    public const short OTP_EXPIRY_DAYS = 1;
    public const short TOKEN_EXPIRY_DAYS = 7;
}

public struct UserRoles
{
    public const string ADMIN_ROLE = "Admin";
    public const string PLAYER_ROLE = "Player";
}

public struct Regions
{
    public const string B_GAME = "b_game";
    public const string VIP_CHARACTER_PERSONALIZE = "vip_chararacter_personalize";
}

public struct JwtClaimNames
{
    public const string USER_ID = "UserId";
    public const string EMAIL = "Email";
    public const string UserName = "UserName";
    public const string FIRST_NAME = "FirstName";
    public const string LAST_NAME = "LastName";
    public const string REGION = "Region";
    public const string FULL_NAME = "FullName";
    public const string JTI = "JWT ID";
    public const string IAT = "Issued At";
    public const string DISPLAY_NAME = "DisplayName";
}

public struct ExceptionMessages
{
    public const string FAILED_TO_START_API = "Error while creating and building generic host builder object";
    public const string UNAUTHORIZED_USER = "User is not authenticated.";
}