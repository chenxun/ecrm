class DelegateWebserviceController < ActionWebService::WebServiceController
	layout false
	web_service_dispatching_mode :delegated
	
	wsdl_service_name 'Ecrm'
	web_service :customer, CustomerService.new
	web_service :user, UserService.new
end
