class UserApi < ActionWebService::API::Base
	api_method :add_user, :expects => [{:user_request=>TdUserRequest}], :returns => [TdUserResult]
	api_method :get_user_by_name, :expects => [{:user_name=>:string}], :returns => [TdUserResult]
end
