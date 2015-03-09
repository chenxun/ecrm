class UserApi < ActionWebService::API::Base
	api_method :add_user, :expects => [{:user_request=>TdUserRequest}], :returns => [TdUserResult]
	api_method :add_department, :expects => [{:name=>:string}], :returns => [Department]
	api_method :get_user_by_name, :expects => [{:user_name=>:string}], :returns => [TdUserResult]
	api_method :get_user_by_id, :expects => [{:user_id => :int}], :returns => [TdUserResult]
	api_method :get_frames_by_user_id, :expects => [{:user_id => :int}], :returns => [[Frame]]
	api_method :get_roles_by_user_id, :expects => [{:user_id => :int}], :returns => [[Role]]
	api_method :get_roles_all, :expects => [], :returns => [[Role]]
	api_method :is_boss, :expects => [{:soldier_id=>:int},{:manager_id=>:int}], :returns => [:bool]
end
