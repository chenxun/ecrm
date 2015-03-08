class CustomerApi < ActionWebService::API::Base
	api_method :add_customer, :expects => [{:customer=>TdCustomerRequest}], :returns => [TdCustomerResult]
	api_method :get_customer_by_id, :expects => [{:customer_id => :int}], :returns => [TdCustomerResult]
	api_method :get_visit_records_by_customer, :expects => [{:customer_id => :int}], :returns => [[VisitRecord]]
	api_method :add_visit_plan, :expects => [{:ss=>:string}], :returns => [VisitPlan]
	api_method :save_customer, :expects => [{:customer=>TdCustomerRequest}], :returns => [TdCustomerResult]
	api_method :customer_user_relation, :expects => [{:customer_id=>:int}, {:user_id=>:int}], :returns => [:int]
end
