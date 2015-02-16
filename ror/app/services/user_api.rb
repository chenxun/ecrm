class UserApi < ActionWebService::API::Base
	api_method :add_user, :expects => [{:user_request=>TdUserRequest}], :returns => [TdUserResult]
end
