class TdUserRequest < ActionWebService::Struct
	member :user_name,		:string
	member :password,		:string
	member :real_name,		:string
end
