import React from 'react';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';

export default class ViewPhotoModal extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            modal: false
        };

        this.toggle = this.toggle.bind(this);
    }

    toggle() {
        this.setState(prevState => ({
            modal: !prevState.modal
        }));
    }

    render() {

        const appComponent = this.props.appComponent;
        const photo = appComponent.state.viewPhotoData;

        return (
            <div>
                <Modal isOpen={appComponent.state.viewPhotoModal} toggle={appComponent.toggleViewPhoto.bind(appComponent)}>
                    <ModalHeader toggle={appComponent.toggleViewPhoto.bind(appComponent)}>View Photo</ModalHeader>
                    <ModalBody>
                        <img src={photo} />
                    </ModalBody>
                    <ModalFooter>
                        <Button color="primary" onClick={appComponent.toggleViewPhoto.bind(appComponent)}>Cancel</Button>
                    </ModalFooter>
                </Modal>
            </div>
        );
    }
}