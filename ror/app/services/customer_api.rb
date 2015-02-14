class CustomerApi < ActionWebService::API::Base
	api_method :add, :expects => [{:str=>:string}], :returns => [Customer]
end
